using Supermarket.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace Supermarket.DAL
{
    internal class SalesDAL
    {
        public static string GenerateInvoiceNumber()
        {
            return "INV-" + DateTime.Now.ToString("yyyyMMddHHmmss") + "-" + new Random().Next(100, 999).ToString();
        }

        // Create Sale
        public bool CreateSale(Sales sale, List<SalesDetails> details, out string errorMessage)
        {
            errorMessage = string.Empty;
            if (sale == null || details == null || details.Count == 0)
            {
                errorMessage = "Invalid sale or empty items list.";
                return false;
            }

            if (string.IsNullOrWhiteSpace(sale.Invoice_number))
                sale.Invoice_number = GenerateInvoiceNumber();

            foreach (var detail in details)
            {
                if (string.IsNullOrWhiteSpace(detail.Invoice_number))
                    detail.Invoice_number = sale.Invoice_number;
            }

            try
            {
                using (var db = new SupermarketContext())
                {
                    var conn = db.Database.Connection;
                    if (conn.State != System.Data.ConnectionState.Open)
                    {
                        conn.Open();
                    }

                    using (var trans = conn.BeginTransaction())
                    {
                        try
                        {
                            sale.User_id = GetOrCreateValidUserId(db, conn, trans);
                            if (!sale.Sale_date.HasValue || sale.Sale_date == default(DateTime))
                                sale.Sale_date = DateTime.Now;

                            if (string.IsNullOrWhiteSpace(sale.Status))
                                sale.Status = "Completed";

                            // 1. Check whether 'sales' table has 'invoice_number' column
                            bool salesHasInvoiceCol = false;
                            using (var cmdCheck = conn.CreateCommand())
                            {
                                cmdCheck.Transaction = trans;
                                cmdCheck.CommandText = "SELECT COUNT(*) FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = 'sales' AND COLUMN_NAME = 'invoice_number'";
                                salesHasInvoiceCol = Convert.ToInt32(cmdCheck.ExecuteScalar()) > 0;
                            }

                            long newSaleId;
                            using (var cmdSale = conn.CreateCommand())
                            {
                                cmdSale.Transaction = trans;
                                if (salesHasInvoiceCol)
                                {
                                    cmdSale.CommandText = @"
                                        INSERT INTO sales (user_id, invoice_number, sale_date, payment_method, status, subtotal, discount_amount, grand_total)
                                        VALUES (@UserId, @InvoiceNumber, @SaleDate, @PaymentMethod, @Status, @Subtotal, @Discount, @GrandTotal);
                                        SELECT CAST(SCOPE_IDENTITY() AS BIGINT);";
                                    cmdSale.Parameters.Add(new SqlParameter("@InvoiceNumber", sale.Invoice_number));
                                }
                                else
                                {
                                    cmdSale.CommandText = @"
                                        INSERT INTO sales (user_id, sale_date, payment_method, status, subtotal, discount_amount, grand_total)
                                        VALUES (@UserId, @SaleDate, @PaymentMethod, @Status, @Subtotal, @Discount, @GrandTotal);
                                        SELECT CAST(SCOPE_IDENTITY() AS BIGINT);";
                                }

                                decimal totalSubtotal = details.Sum(d => d.Subtotal);
                                cmdSale.Parameters.Add(new SqlParameter("@UserId", sale.User_id));
                                cmdSale.Parameters.Add(new SqlParameter("@SaleDate", sale.Sale_date.Value));
                                cmdSale.Parameters.Add(new SqlParameter("@PaymentMethod", (object)sale.Payment_method ?? "Cash"));
                                cmdSale.Parameters.Add(new SqlParameter("@Status", sale.Status));
                                cmdSale.Parameters.Add(new SqlParameter("@Subtotal", (object)sale.Subtotal ?? totalSubtotal));
                                cmdSale.Parameters.Add(new SqlParameter("@Discount", (object)sale.Discount_amount ?? 0m));
                                cmdSale.Parameters.Add(new SqlParameter("@GrandTotal", (object)sale.Grand_total ?? totalSubtotal));

                                object result = cmdSale.ExecuteScalar();
                                newSaleId = Convert.ToInt64(result);
                                sale.Id = newSaleId;
                            }

                            // 2. Check if 'sale_details' has 'invoice_number' column
                            bool detailsHasInvoiceCol = false;
                            using (var cmdCheck = conn.CreateCommand())
                            {
                                cmdCheck.Transaction = trans;
                                cmdCheck.CommandText = "SELECT COUNT(*) FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = 'sale_details' AND COLUMN_NAME = 'invoice_number'";
                                detailsHasInvoiceCol = Convert.ToInt32(cmdCheck.ExecuteScalar()) > 0;
                            }

                            // 3. Insert each item into 'sale_details' and deduct product stock
                            foreach (var item in details)
                            {
                                item.Sale_id = newSaleId;

                                using (var cmdDetail = conn.CreateCommand())
                                {
                                    cmdDetail.Transaction = trans;
                                    if (detailsHasInvoiceCol)
                                    {
                                        cmdDetail.CommandText = @"
                                            INSERT INTO sale_details (sale_id, invoice_number, product_id, quantity, unit_price, subtotal)
                                            VALUES (@SaleId, @InvoiceNumber, @ProductId, @Quantity, @UnitPrice, @Subtotal);";
                                        cmdDetail.Parameters.Add(new SqlParameter("@InvoiceNumber", item.Invoice_number ?? sale.Invoice_number));
                                    }
                                    else
                                    {
                                        cmdDetail.CommandText = @"
                                            INSERT INTO sale_details (sale_id, product_id, quantity, unit_price, subtotal)
                                            VALUES (@SaleId, @ProductId, @Quantity, @UnitPrice, @Subtotal);";
                                    }

                                    cmdDetail.Parameters.Add(new SqlParameter("@SaleId", newSaleId));
                                    cmdDetail.Parameters.Add(new SqlParameter("@ProductId", item.Product_id));
                                    cmdDetail.Parameters.Add(new SqlParameter("@Quantity", item.Quantity));
                                    cmdDetail.Parameters.Add(new SqlParameter("@UnitPrice", item.Unit_price));
                                    cmdDetail.Parameters.Add(new SqlParameter("@Subtotal", item.Subtotal));

                                    cmdDetail.ExecuteNonQuery();
                                }

                                // Deduct product stock
                                using (var cmdStock = conn.CreateCommand())
                                {
                                    cmdStock.Transaction = trans;
                                    cmdStock.CommandText = @"
                                        UPDATE products
                                        SET stock_quantity = CASE WHEN stock_quantity - @Qty < 0 THEN 0 ELSE stock_quantity - @Qty END
                                        WHERE id = @ProductId;";
                                    cmdStock.Parameters.Add(new SqlParameter("@Qty", item.Quantity));
                                    cmdStock.Parameters.Add(new SqlParameter("@ProductId", item.Product_id));
                                    cmdStock.ExecuteNonQuery();
                                }
                            }

                            trans.Commit();
                            return true;
                        }
                        catch (Exception ex)
                        {
                            trans.Rollback();
                            errorMessage = GetFullErrorMessage(ex);
                            return false;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                errorMessage = GetFullErrorMessage(ex);
                return false;
            }
        }

        // Cancel Sale
        public bool CancelSale(long saleId, out string errorMessage)
        {
            errorMessage = string.Empty;
            if (saleId <= 0)
            {
                errorMessage = "Invalid sale ID.";
                return false;
            }

            try
            {
                using (var db = new SupermarketContext())
                {
                    var conn = db.Database.Connection;
                    if (conn.State != System.Data.ConnectionState.Open)
                    {
                        conn.Open();
                    }

                    using (var trans = conn.BeginTransaction())
                    {
                        try
                        {
                            // 1. Check current status
                            string currentStatus = null;
                            using (var cmdStatus = conn.CreateCommand())
                            {
                                cmdStatus.Transaction = trans;
                                cmdStatus.CommandText = "SELECT status FROM sales WHERE id = @SaleId";
                                cmdStatus.Parameters.Add(new SqlParameter("@SaleId", saleId));
                                var obj = cmdStatus.ExecuteScalar();
                                if (obj != null && obj != DBNull.Value)
                                {
                                    currentStatus = obj.ToString();
                                }
                            }

                            if (string.IsNullOrWhiteSpace(currentStatus))
                            {
                                errorMessage = "Sale not found in database.";
                                trans.Rollback();
                                return false;
                            }

                            if (currentStatus.StartsWith("Cancel", StringComparison.OrdinalIgnoreCase))
                            {
                                errorMessage = "This sale has already been cancelled.";
                                trans.Rollback();
                                return false;
                            }

                            // 2. Update status to 'Cancelled'
                            using (var cmdUpdate = conn.CreateCommand())
                            {
                                cmdUpdate.Transaction = trans;
                                cmdUpdate.CommandText = "UPDATE sales SET status = 'Cancelled' WHERE id = @SaleId";
                                cmdUpdate.Parameters.Add(new SqlParameter("@SaleId", saleId));
                                cmdUpdate.ExecuteNonQuery();
                            }

                            // 3. Restore product stock quantities
                            using (var cmdRestore = conn.CreateCommand())
                            {
                                cmdRestore.Transaction = trans;
                                cmdRestore.CommandText = @"
                                    UPDATE p
                                    SET p.stock_quantity = p.stock_quantity + sd.quantity
                                    FROM products p
                                    INNER JOIN sale_details sd ON p.id = sd.product_id
                                    WHERE sd.sale_id = @SaleId;";
                                cmdRestore.Parameters.Add(new SqlParameter("@SaleId", saleId));
                                cmdRestore.ExecuteNonQuery();
                            }

                            trans.Commit();
                            return true;
                        }
                        catch (Exception ex)
                        {
                            trans.Rollback();
                            errorMessage = GetFullErrorMessage(ex);
                            return false;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                errorMessage = GetFullErrorMessage(ex);
                return false;
            }
        }

        // Update Sale Status
        public bool UpdateSaleStatus(long saleId, string newStatus, out string errorMessage)
        {
            errorMessage = string.Empty;
            if (saleId <= 0)
            {
                errorMessage = "Invalid sale ID.";
                return false;
            }

            if (string.Equals(newStatus, "Cancelled", StringComparison.OrdinalIgnoreCase) ||
                string.Equals(newStatus, "Canceled", StringComparison.OrdinalIgnoreCase))
            {
                return CancelSale(saleId, out errorMessage);
            }

            try
            {
                using (var db = new SupermarketContext())
                {
                    var paramId = new SqlParameter("@Id", saleId);
                    var paramStatus = new SqlParameter("@Status", newStatus);

                    int rows = db.Database.ExecuteSqlCommand("UPDATE sales SET status = @Status WHERE id = @Id", paramStatus, paramId);
                    if (rows > 0)
                    {
                        return true;
                    }
                    else
                    {
                        errorMessage = "Sale record not found.";
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                errorMessage = GetFullErrorMessage(ex);
                return false;
            }
        }

        private long GetOrCreateValidUserId(SupermarketContext db, System.Data.Common.DbConnection conn, System.Data.Common.DbTransaction trans)
        {
            try
            {
                using (var cmd = conn.CreateCommand())
                {
                    cmd.Transaction = trans;
                    cmd.CommandText = "SELECT TOP 1 id FROM users";
                    var obj = cmd.ExecuteScalar();
                    if (obj != null && obj != DBNull.Value)
                    {
                        return Convert.ToInt64(obj);
                    }
                }

                // If no user exists, create role and user
                using (var cmd = conn.CreateCommand())
                {
                    cmd.Transaction = trans;
                    cmd.CommandText = "SELECT TOP 1 id FROM roles";
                    var rObj = cmd.ExecuteScalar();
                    int roleId;
                    if (rObj == null || rObj == DBNull.Value)
                    {
                        cmd.CommandText = "INSERT INTO roles (name, description) VALUES ('Admin', 'System Administrator'); SELECT SCOPE_IDENTITY();";
                        roleId = Convert.ToInt32(cmd.ExecuteScalar());
                    }
                    else
                    {
                        roleId = Convert.ToInt32(rObj);
                    }

                    cmd.CommandText = "INSERT INTO users (role_id, username, password, status) VALUES (@p0, 'admin', '123456', 'active'); SELECT SCOPE_IDENTITY();";
                    cmd.Parameters.Clear();
                    cmd.Parameters.Add(new SqlParameter("@p0", roleId));
                    return Convert.ToInt64(cmd.ExecuteScalar());
                }
            }
            catch
            {
                return 1;
            }
        }

        private string GetFullErrorMessage(Exception ex)
        {
            if (ex == null) return "";
            string msg = ex.Message;
            Exception inner = ex.InnerException;
            while (inner != null)
            {
                if (!string.IsNullOrWhiteSpace(inner.Message))
                {
                    msg += "\n-> " + inner.Message;
                }
                inner = inner.InnerException;
            }
            return msg;
        }
    }
}

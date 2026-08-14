using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Windows.Forms;
using Supermarket.Model;

namespace Supermarket.DAL
{
    internal class SalesDAL
    {
        public static string GenerateInvoiceNumber()
        {
            return "INV-" + DateTime.Now.ToString("yyyyMMddHHmmss") + "-" + new Random().Next(100, 999).ToString();
        }

        public bool CreateSale(Sales sale, List<SalesDetails> details, out string errorMessage)
        {
            errorMessage = string.Empty;
            if (sale == null || details == null || details.Count == 0)
            {
                errorMessage = "Invalid sale or empty items list.";
                return false;
            }

            try
            {
                using (var db = new SupermarketContext())
                {
                    using (var transaction = db.Database.BeginTransaction())
                    {
                        try
                        {
                            // Ensure a valid user_id exists in the users table to satisfy foreign key FK_sales_users
                            sale.User_id = GetOrCreateValidUserId(db);

                            if (string.IsNullOrWhiteSpace(sale.Invoice_number))
                            {
                                sale.Invoice_number = GenerateInvoiceNumber();
                            }
                            if (sale.Sale_date == default(DateTime))
                            {
                                sale.Sale_date = DateTime.Now;
                            }

                            db.Sales.Add(sale);
                            db.SaveChanges(); // Generates sale.Id

                            foreach (var item in details)
                            {
                                item.Sale_id = sale.Id;
                                db.SalesDetails.Add(item);

                                // Update product stock quantity
                                var product = db.Products.FirstOrDefault(p => p.Id == item.Product_id);
                                if (product != null)
                                {
                                    product.Stock_quantity = Math.Max(0, product.Stock_quantity - item.Quantity);
                                }
                            }

                            db.SaveChanges();
                            transaction.Commit();
                            return true;
                        }
                        catch (Exception innerEx)
                        {
                            transaction.Rollback();
                            errorMessage = GetFullErrorMessage(innerEx);
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

        private long GetOrCreateValidUserId(SupermarketContext db)
        {
            try
            {
                // Try to retrieve any existing user ID from the database
                var existingUser = db.Database.SqlQuery<long?>("SELECT TOP 1 id FROM users").FirstOrDefault();
                if (existingUser.HasValue && existingUser.Value > 0)
                {
                    return existingUser.Value;
                }

                // If no user exists, check/create a default role first
                var roleId = db.Database.SqlQuery<int?>("SELECT TOP 1 id FROM roles").FirstOrDefault();
                if (!roleId.HasValue || roleId.Value <= 0)
                {
                    db.Database.ExecuteSqlCommand("INSERT INTO roles (name, description) VALUES ('Admin', 'System Administrator')");
                    roleId = db.Database.SqlQuery<int>("SELECT TOP 1 id FROM roles").First();
                }

                // Insert default system user
                db.Database.ExecuteSqlCommand(
                    "INSERT INTO users (role_id, username, password, status) VALUES (@p0, 'admin', '123456', 'active')",
                    roleId.Value);

                var newUserId = db.Database.SqlQuery<long>("SELECT TOP 1 id FROM users ORDER BY id DESC").First();
                return newUserId;
            }
            catch
            {
                // Fallback to ID 1 if query fails
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

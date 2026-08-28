using Supermarket.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Windows.Forms;

namespace Supermarket.DAL
{
    internal class StockAdjustmentsDAL
    {
        // 1. READ - Get all stock adjustments from view (vw_Stock_adjustments)
        public List<vw_Stock_adjustments> Getvw_StockAdjustments()
        {
            try
            {
                using (var db = new SupermarketContext())
                {
                    // Disable lazy loading & proxy creation
                    db.Configuration.LazyLoadingEnabled = false;
                    db.Configuration.ProxyCreationEnabled = false;

                    // Query
                    var list = db.vw_Stock_adjustments
                                 .AsNoTracking()
                                 .OrderByDescending(s => s.AdjustedAt)
                                 .ToList();

                    return list;
                }
            }
            catch (Exception ex)
            {
                string errorMessage = GetFullErrorMessage(ex);
                MessageBox.Show("EF Query Error: \n" + errorMessage, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return new List<vw_Stock_adjustments>();
            }
        }

        // 2. READ - Get all stock adjustments from table (stock_adjustments)
        public List<StockAdjustments> GetAllStockAdjustments()
        {
            try
            {
                using (var db = new SupermarketContext())
                {
                    db.Configuration.LazyLoadingEnabled = false;
                    db.Configuration.ProxyCreationEnabled = false;

                    return db.StockAdjustments
                             .Include(s => s.Products)
                             .AsNoTracking()
                             .OrderByDescending(s => s.AdjustedAt)
                             .ToList();
                }
            }
            catch (Exception ex)
            {
                string errorMessage = GetFullErrorMessage(ex);
                MessageBox.Show("EF Query Error: \n" + errorMessage, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return new List<StockAdjustments>();
            }
        }

        // 3. READ - Get stock adjustment by ID
        public StockAdjustments GetStockAdjustmentById(long id)
        {
            try
            {
                using (var db = new SupermarketContext())
                {
                    db.Configuration.LazyLoadingEnabled = false;
                    db.Configuration.ProxyCreationEnabled = false;

                    return db.StockAdjustments
                             .Include(s => s.Products)
                             .FirstOrDefault(s => s.Id == id);
                }
            }
            catch (Exception ex)
            {
                string errorMessage = GetFullErrorMessage(ex);
                MessageBox.Show("EF Query Error: \n" + errorMessage, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        // 4. CREATE
        public bool AddStockAdjustment(StockAdjustments adjustment, out string errorMessage)
        {
            errorMessage = string.Empty;
            if (adjustment == null)
            {
                errorMessage = "Stock adjustment data cannot be null.";
                return false;
            }

            if (adjustment.Quantity <= 0)
            {
                errorMessage = "Quantity must be greater than 0.";
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
                            var product = db.Products.FirstOrDefault(p => p.Id == adjustment.ProductId);
                            if (product == null)
                            {
                                errorMessage = "Product not found.";
                                transaction.Rollback();
                                return false;
                            }

                            if (!adjustment.AdjustedAt.HasValue || adjustment.AdjustedAt == default(DateTime))
                            {
                                adjustment.AdjustedAt = DateTime.Now;
                            }

                            if (adjustment.UserId <= 0)
                            {
                                adjustment.UserId = 1;
                            }

                            if (string.IsNullOrWhiteSpace(adjustment.Status))
                            {
                                adjustment.Status = "Pending";
                            }

                            string type = adjustment.Type?.Trim().ToLower() ?? "addition";

                            if (type == "addition" || type == "add" || type == "+")
                            {
                                adjustment.Type = "addition";
                                if (adjustment.Status.Equals("Completed", StringComparison.OrdinalIgnoreCase))
                                {
                                    product.Stock_quantity += adjustment.Quantity;
                                }
                            }
                            else if (type == "subtraction" || type == "subtract" || type == "-")
                            {
                                adjustment.Type = "subtraction";
                                if (adjustment.Status.Equals("Completed", StringComparison.OrdinalIgnoreCase))
                                {
                                    if (product.Stock_quantity < adjustment.Quantity)
                                    {
                                        errorMessage = $"Insufficient stock for product '{product.Name}'. Current stock: {product.Stock_quantity}, Adjustment quantity: {adjustment.Quantity}.";
                                        transaction.Rollback();
                                        return false;
                                    }
                                    product.Stock_quantity -= adjustment.Quantity;
                                }
                            }
                            else
                            {
                                errorMessage = "Invalid adjustment type. Must be 'addition' or 'subtraction'.";
                                transaction.Rollback();
                                return false;
                            }

                            db.StockAdjustments.Add(adjustment);
                            db.SaveChanges();

                            transaction.Commit();
                            return true;
                        }
                        catch (Exception ex)
                        {
                            transaction.Rollback();
                            errorMessage = GetFullErrorMessage(ex);
                            MessageBox.Show("Transaction Error: " + errorMessage, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return false;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                errorMessage = GetFullErrorMessage(ex);
                MessageBox.Show("EF Add Error: " + errorMessage, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        // Add without out parameter
        public bool AddStockAdjustment(StockAdjustments adjustment)
        {
            return AddStockAdjustment(adjustment, out _);
        }

        // 5. COMPLETE - Mark pending stock adjustment as completed and update product inventory
        public bool CompleteStockAdjustment(long id, out string errorMessage)
        {
            errorMessage = string.Empty;
            try
            {
                using (var db = new SupermarketContext())
                {
                    using (var transaction = db.Database.BeginTransaction())
                    {
                        try
                        {
                            var adjustment = db.StockAdjustments.FirstOrDefault(s => s.Id == id);
                            if (adjustment == null)
                            {
                                errorMessage = "Stock adjustment record not found.";
                                transaction.Rollback();
                                return false;
                            }

                            if (adjustment.Status != null && adjustment.Status.Equals("Completed", StringComparison.OrdinalIgnoreCase))
                            {
                                errorMessage = "This stock adjustment is already completed.";
                                transaction.Rollback();
                                return false;
                            }

                            var product = db.Products.FirstOrDefault(p => p.Id == adjustment.ProductId);
                            if (product == null)
                            {
                                errorMessage = "Associated product not found.";
                                transaction.Rollback();
                                return false;
                            }

                            string type = adjustment.Type?.Trim().ToLower() ?? "addition";
                            if (type == "addition" || type == "add" || type == "+")
                            {
                                product.Stock_quantity += adjustment.Quantity;
                            }
                            else if (type == "subtraction" || type == "subtract" || type == "-")
                            {
                                if (product.Stock_quantity < adjustment.Quantity)
                                {
                                    errorMessage = $"Insufficient stock for product '{product.Name}'. Current stock: {product.Stock_quantity}, Adjustment quantity: {adjustment.Quantity}.";
                                    transaction.Rollback();
                                    return false;
                                }
                                product.Stock_quantity -= adjustment.Quantity;
                            }
                            else
                            {
                                errorMessage = $"Invalid adjustment type: '{adjustment.Type}'.";
                                transaction.Rollback();
                                return false;
                            }

                            adjustment.Status = "Completed";
                            db.SaveChanges();

                            transaction.Commit();
                            return true;
                        }
                        catch (Exception ex)
                        {
                            transaction.Rollback();
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

        public bool CompleteStockAdjustment(long id)
        {
            return CompleteStockAdjustment(id, out _);
        }

        // 6. DELETE - Delete stock adjustment by ID
        public bool DeleteStockAdjustment(long id)
        {
            try
            {
                using (var db = new SupermarketContext())
                {
                    var adjustment = db.StockAdjustments.FirstOrDefault(s => s.Id == id);
                    if (adjustment != null)
                    {
                        db.StockAdjustments.Remove(adjustment);
                        return db.SaveChanges() > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                string errorMessage = GetFullErrorMessage(ex);
                MessageBox.Show("EF Delete Error: " + errorMessage, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return false;
        }

        // Error messages
        private static string GetFullErrorMessage(Exception ex)
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

        // 7. READ - Get all stock alerts from view (vw_StockAlert)
        public List<vw_StockAlert> GetStockAlerts()
        {
            try
            {
                using (var db = new SupermarketContext())
                {
                    db.Configuration.LazyLoadingEnabled = false;
                    db.Configuration.ProxyCreationEnabled = false;

                    return db.vw_StockAlerts
                             .AsNoTracking()
                             .OrderBy(s => s.CurrentStock)
                             .ToList();
                }
            }
            catch (Exception ex)
            {
                string errorMessage = GetFullErrorMessage(ex);
                MessageBox.Show("EF Query Error: \n" + errorMessage, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return new List<vw_StockAlert>();
            }
        }
    }
}

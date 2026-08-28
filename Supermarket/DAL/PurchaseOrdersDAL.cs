using Supermarket.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Supermarket.DAL
{
    internal class PurchaseOrdersDAL
    {
        // READ - Get all purchase orders from view
        public List<vw_PurchasesOrder> GetAllPurchaseOrders()
        {
            try
            {
                using (var db = new SupermarketContext())
                {
                    db.Configuration.LazyLoadingEnabled = false;
                    db.Configuration.ProxyCreationEnabled = false;
                    return db.vw_PurchasesOrders
                             .AsNoTracking()
                             .OrderByDescending(p => p.PurchaseDate)
                             .ToList();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("EF Query Error: " + GetFullErrorMessage(ex), "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return new List<vw_PurchasesOrder>();
            }
        }

        // READ - Get purchase orders filtered by date range
        public List<vw_PurchasesOrder> GetPurchaseOrdersByDateRange(DateTime startDate, DateTime endDate)
        {
            try
            {
                using (var db = new SupermarketContext())
                {
                    db.Configuration.LazyLoadingEnabled = false;
                    db.Configuration.ProxyCreationEnabled = false;
                    DateTime start = startDate.Date;
                    DateTime end = endDate.Date.AddDays(1).AddTicks(-1);

                    return db.vw_PurchasesOrders
                             .AsNoTracking()
                             .Where(p => p.PurchaseDate >= start && p.PurchaseDate <= end)
                             .OrderByDescending(p => p.PurchaseDate)
                             .ToList();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("EF Query Error: " + GetFullErrorMessage(ex), "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return new List<vw_PurchasesOrder>();
            }
        }

        // READ - Get single purchase order line item by Detail ID
        public vw_PurchasesOrder GetPurchaseOrderById(long detailId)
        {
            try
            {
                using (var db = new SupermarketContext())
                {
                    db.Configuration.LazyLoadingEnabled = false;
                    db.Configuration.ProxyCreationEnabled = false;
                    return db.vw_PurchasesOrders
                             .AsNoTracking()
                             .FirstOrDefault(p => p.PurchaseDetailID == detailId);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("EF Query Error: " + GetFullErrorMessage(ex), "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        // GENERATE - Unique Purchase Number
        public string GenerateNextPurchaseNumber()
        {
            try
            {
                using (var db = new SupermarketContext())
                {
                    string prefix = "PO-" + DateTime.Now.ToString("yyyyMMdd") + "-";
                    var existing = db.Purchases
                                     .AsNoTracking()
                                     .Where(p => p.PurchaseNumber.StartsWith(prefix))
                                     .Select(p => p.PurchaseNumber)
                                     .ToList();

                    int maxNumber = 0;
                    foreach (var num in existing)
                    {
                        string suffix = num.Substring(prefix.Length);
                        if (int.TryParse(suffix, out int parsed))
                        {
                            if (parsed > maxNumber) maxNumber = parsed;
                        }
                    }

                    return prefix + (maxNumber + 1).ToString("D4");
                }
            }
            catch
            {
                return "PO-" + DateTime.Now.ToString("yyyyMMddHHmmss");
            }
        }

        // CREATE - Add a complete new Purchase Order with detail line items and stock increment
        public bool CreatePurchaseOrder(Purchases purchase, List<PurchaseDetails> details, out string errorMessage)
        {
            errorMessage = "";
            try
            {
                using (var db = new SupermarketContext())
                {
                    using (var transaction = db.Database.BeginTransaction())
                    {
                        try
                        {
                            // 1. Calculate total if not set
                            if (purchase.TotalAmount == null || purchase.TotalAmount == 0)
                            {
                                purchase.TotalAmount = details.Sum(d => d.Subtotal);
                            }

                            // 2. Insert main purchase record
                            db.Purchases.Add(purchase);
                            db.SaveChanges(); // to get purchase.PurchaseId

                            long purchaseId = purchase.PurchaseId;

                            // 3. Insert line items & update product stock & cost price
                            foreach (var item in details)
                            {
                                item.PurchaseId = purchaseId;
                                db.PurchaseDetails.Add(item);

                                // If status is received (or default), increment product stock
                                if (string.IsNullOrEmpty(purchase.Status) || purchase.Status.ToLower() == "received")
                                {
                                    var product = db.Products.FirstOrDefault(p => p.Id == item.ProductId);
                                    if (product != null)
                                    {
                                        product.Stock_quantity += item.Quantity;
                                        if (item.UnitCost > 0)
                                        {
                                            product.Cost_price = item.UnitCost;
                                        }
                                    }
                                }
                            }

                            db.SaveChanges();
                            transaction.Commit();
                            return true;
                        }
                        catch (Exception ex)
                        {
                            transaction.Rollback();
                            errorMessage = GetFullErrorMessage(ex);
                            MessageBox.Show("Failed to save Purchase Order: " + errorMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return false;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                errorMessage = GetFullErrorMessage(ex);
                MessageBox.Show("Database connection error: " + errorMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        // UPDATE - Mark a pending purchase as received and increment inventory stock
        public bool MarkPurchaseAsReceived(long purchaseId, out string errorMessage)
        {
            errorMessage = "";
            try
            {
                using (var db = new SupermarketContext())
                {
                    using (var transaction = db.Database.BeginTransaction())
                    {
                        try
                        {
                            var purchase = db.Purchases.FirstOrDefault(p => p.PurchaseId == purchaseId);
                            if (purchase == null)
                            {
                                errorMessage = "Purchase order not found.";
                                return false;
                            }

                            if (purchase.Status != null && purchase.Status.ToLower() == "received")
                            {
                                errorMessage = "This purchase order has already been marked as received.";
                                return false;
                            }

                            purchase.Status = "received";

                            // Increment stock for all items
                            var items = db.PurchaseDetails.Where(d => d.PurchaseId == purchaseId).ToList();
                            foreach (var item in items)
                            {
                                var product = db.Products.FirstOrDefault(p => p.Id == item.ProductId);
                                if (product != null)
                                {
                                    product.Stock_quantity += item.Quantity;
                                    if (item.UnitCost > 0)
                                    {
                                        product.Cost_price = item.UnitCost;
                                    }
                                }
                            }

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

        // CANCEL - Mark purchase order as canceled and rollback inventory stock if it was previously received
        public bool CancelPurchaseOrder(long purchaseId, out string errorMessage)
        {
            errorMessage = "";
            try
            {
                using (var db = new SupermarketContext())
                {
                    using (var transaction = db.Database.BeginTransaction())
                    {
                        try
                        {
                            var purchase = db.Purchases.FirstOrDefault(p => p.PurchaseId == purchaseId);
                            if (purchase == null)
                            {
                                errorMessage = "Purchase order not found.";
                                return false;
                            }

                            if (purchase.Status != null && (purchase.Status.Equals("canceled", StringComparison.OrdinalIgnoreCase) || purchase.Status.Equals("cancelled", StringComparison.OrdinalIgnoreCase)))
                            {
                                errorMessage = "This purchase order has already been canceled.";
                                return false;
                            }

                            bool wasReceived = purchase.Status != null && purchase.Status.Equals("received", StringComparison.OrdinalIgnoreCase);

                            purchase.Status = "canceled";

                            // If it was already received, restore / deduct stock
                            if (wasReceived)
                            {
                                var items = db.PurchaseDetails.Where(d => d.PurchaseId == purchaseId).ToList();
                                foreach (var item in items)
                                {
                                    var product = db.Products.FirstOrDefault(p => p.Id == item.ProductId);
                                    if (product != null)
                                    {
                                        product.Stock_quantity = Math.Max(0, product.Stock_quantity - item.Quantity);
                                    }
                                }
                            }

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

        private string GetFullErrorMessage(Exception ex)
        {
            StringBuilder sb = new StringBuilder();
            Exception current = ex;
            while (current != null)
            {
                sb.AppendLine(current.Message);
                current = current.InnerException;
            }
            return sb.ToString();
        }
    }
}

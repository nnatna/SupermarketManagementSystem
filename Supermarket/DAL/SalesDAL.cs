using Supermarket.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Supermarket.DAL
{
    internal class SalesDAL
    {
        public static string GenerateInvoiceNumber()
        {
            return "INV-" + DateTime.Now.ToString("yyyyMMddHHmmss") + "-" + new Random().Next(100, 999).ToString();
        }

        // CREATE SALE - Pure Entity Framework ORM
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
                    using (var trans = db.Database.BeginTransaction())
                    {
                        try
                        {
                            // 1. Ensure user_id is valid
                            sale.User_id = GetOrCreateValidUserId(db);
                            if (!sale.Sale_date.HasValue || sale.Sale_date == default(DateTime))
                                sale.Sale_date = DateTime.Now;

                            if (string.IsNullOrWhiteSpace(sale.Status))
                                sale.Status = "Completed";

                            decimal totalSubtotal = details.Sum(d => d.Subtotal);
                            if (!sale.Subtotal.HasValue || sale.Subtotal == 0m)
                                sale.Subtotal = totalSubtotal;

                            if (!sale.Grand_total.HasValue || sale.Grand_total == 0m)
                                sale.Grand_total = (sale.Subtotal ?? totalSubtotal) - (sale.Discount_amount ?? 0m);

                            // 2. Add Sale entity via EF
                            db.Sales.Add(sale);
                            db.SaveChanges(); // Generates sale.Id

                            // 3. Award loyalty points to customer if applicable
                            if (sale.Customer_id.HasValue && sale.Customer_id.Value > 0)
                            {
                                var customer = db.Customers.FirstOrDefault(c => c.Id == sale.Customer_id.Value);
                                if (customer != null)
                                {
                                    int earnedPoints = (int)Math.Round(sale.Grand_total ?? 0m, MidpointRounding.AwayFromZero);
                                    if (earnedPoints <= 0 && (sale.Grand_total ?? 0m) > 0m)
                                    {
                                        earnedPoints = 1;
                                    }
                                    customer.Points += earnedPoints;
                                }
                            }

                            // 4. Add SaleDetails & update product stock via EF
                            foreach (var item in details)
                            {
                                item.Sale_id = sale.Id;
                                db.SalesDetails.Add(item);

                                var product = db.Products.FirstOrDefault(p => p.Id == item.Product_id);
                                if (product != null)
                                {
                                    product.Stock_quantity = Math.Max(0, product.Stock_quantity - item.Quantity);
                                }
                            }

                            db.SaveChanges();
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

        // CANCEL SALE - Pure Entity Framework ORM
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
                    using (var trans = db.Database.BeginTransaction())
                    {
                        try
                        {
                            // 1. Fetch sale
                            var sale = db.Sales.FirstOrDefault(s => s.Id == saleId);
                            if (sale == null)
                            {
                                errorMessage = "Sale not found in database.";
                                trans.Rollback();
                                return false;
                            }

                            if (sale.Status != null && sale.Status.StartsWith("Cancel", StringComparison.OrdinalIgnoreCase))
                            {
                                errorMessage = "This sale has already been cancelled.";
                                trans.Rollback();
                                return false;
                            }

                            // 2. Mark as Cancelled
                            sale.Status = "Cancelled";

                            // 3. Restore product stock quantities & mark details as Cancelled
                            var details = db.SalesDetails.Where(sd => sd.Sale_id == saleId).ToList();
                            foreach (var item in details)
                            {
                                if (item.Status == null || !item.Status.StartsWith("Cancel", StringComparison.OrdinalIgnoreCase))
                                {
                                    item.Status = "Cancelled";
                                    var product = db.Products.FirstOrDefault(p => p.Id == item.Product_id);
                                    if (product != null)
                                    {
                                        product.Stock_quantity += item.Quantity;
                                    }
                                }
                            }

                            // 4. Deduct loyalty points if applicable
                            if (sale.Customer_id.HasValue && sale.Customer_id.Value > 0)
                            {
                                var customer = db.Customers.FirstOrDefault(c => c.Id == sale.Customer_id.Value);
                                if (customer != null)
                                {
                                    int pointsToDeduct = (int)Math.Round(sale.Grand_total ?? 0m, MidpointRounding.AwayFromZero);
                                    if (pointsToDeduct <= 0 && (sale.Grand_total ?? 0m) > 0m) pointsToDeduct = 1;
                                    customer.Points = Math.Max(0, customer.Points - pointsToDeduct);
                                }
                            }

                            db.SaveChanges();
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

        // CANCEL SINGLE SALE ITEM - Pure Entity Framework ORM
        public bool CancelSaleItem(long saleDetailId, out string errorMessage)
        {
            errorMessage = string.Empty;
            if (saleDetailId <= 0)
            {
                errorMessage = "Invalid sale item ID.";
                return false;
            }

            try
            {
                using (var db = new SupermarketContext())
                {
                    using (var trans = db.Database.BeginTransaction())
                    {
                        try
                        {
                            // 1. Fetch sale detail item
                            var item = db.SalesDetails.FirstOrDefault(sd => sd.Id == saleDetailId);
                            if (item == null)
                            {
                                errorMessage = "Sale item not found in database.";
                                trans.Rollback();
                                return false;
                            }

                            if (item.Status != null && item.Status.StartsWith("Cancel", StringComparison.OrdinalIgnoreCase))
                            {
                                errorMessage = "This item has already been cancelled.";
                                trans.Rollback();
                                return false;
                            }

                            // 2. Fetch parent sale
                            var sale = db.Sales.FirstOrDefault(s => s.Id == item.Sale_id);
                            if (sale == null)
                            {
                                errorMessage = "Associated sale invoice not found.";
                                trans.Rollback();
                                return false;
                            }

                            // 3. Mark item as Cancelled
                            item.Status = "Cancelled";

                            // 4. Restore product stock for this item only
                            var product = db.Products.FirstOrDefault(p => p.Id == item.Product_id);
                            if (product != null)
                            {
                                product.Stock_quantity += item.Quantity;
                            }

                            // 5. Update Sale Grand Total and Status
                            var allDetails = db.SalesDetails.Where(sd => sd.Sale_id == sale.Id).ToList();
                            bool allCancelled = allDetails.All(d => d.Id == item.Id || (d.Status != null && d.Status.StartsWith("Cancel", StringComparison.OrdinalIgnoreCase)));

                            decimal newActiveSubtotal = allDetails
                                .Where(d => d.Id != item.Id && (d.Status == null || !d.Status.StartsWith("Cancel", StringComparison.OrdinalIgnoreCase)))
                                .Sum(d => d.Subtotal);

                            if (allCancelled)
                            {
                                sale.Status = "Cancelled";
                                sale.Grand_total = 0;
                            }
                            else
                            {
                                sale.Subtotal = newActiveSubtotal;
                                sale.Grand_total = Math.Max(0, newActiveSubtotal - (sale.Discount_amount ?? 0m));
                            }

                            // 6. Deduct loyalty points for the cancelled item value
                            if (sale.Customer_id.HasValue && sale.Customer_id.Value > 0)
                            {
                                var customer = db.Customers.FirstOrDefault(c => c.Id == sale.Customer_id.Value);
                                if (customer != null)
                                {
                                    int pointsToDeduct = (int)Math.Round(item.Subtotal, MidpointRounding.AwayFromZero);
                                    if (pointsToDeduct <= 0 && item.Subtotal > 0m) pointsToDeduct = 1;
                                    customer.Points = Math.Max(0, customer.Points - pointsToDeduct);
                                }
                            }

                            db.SaveChanges();
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

        // UPDATE SALE STATUS - Pure Entity Framework ORM
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
                    var sale = db.Sales.FirstOrDefault(s => s.Id == saleId);
                    if (sale == null)
                    {
                        errorMessage = "Sale record not found.";
                        return false;
                    }

                    sale.Status = newStatus;
                    return db.SaveChanges() > 0;
                }
            }
            catch (Exception ex)
            {
                errorMessage = GetFullErrorMessage(ex);
                return false;
            }
        }

        // READ - Get single sale with details
        public Sales GetSaleById(long saleId)
        {
            try
            {
                using (var db = new SupermarketContext())
                {
                    db.Configuration.LazyLoadingEnabled = false;
                    db.Configuration.ProxyCreationEnabled = false;

                    return db.Sales
                             .Include(s => s.SaleDetails.Select(d => d.Products))
                             .FirstOrDefault(s => s.Id == saleId);
                }
            }
            catch
            {
                return null;
            }
        }

        private long GetOrCreateValidUserId(SupermarketContext db)
        {
            try
            {
                var firstUser = db.Users.FirstOrDefault();
                if (firstUser != null)
                {
                    return firstUser.Id;
                }

                // If no user exists, create role and user using EF
                var adminRole = db.Roles.FirstOrDefault(r => r.Name == "Admin");
                if (adminRole == null)
                {
                    adminRole = new Roles
                    {
                        Name = "Admin",
                        Description = "System Administrator",
                        CreatedAt = DateTime.Now
                    };
                    db.Roles.Add(adminRole);
                    db.SaveChanges();
                }

                var defaultUser = new Users
                {
                    RoleId = adminRole.Id,
                    Username = "admin",
                    Password = UsersDAL.HashPassword("123456"),
                    Status = "Active",
                    CreatedAt = DateTime.Now
                };
                db.Users.Add(defaultUser);
                db.SaveChanges();

                return defaultUser.Id;
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

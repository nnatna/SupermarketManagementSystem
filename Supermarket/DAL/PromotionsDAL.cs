using Supermarket.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Supermarket.DAL
{
    public class PromotionsDAL
    {
        // READ - Get all promotions with product details
        public List<Promotions> GetAllPromotions()
        {
            try
            {
                using (var db = new SupermarketContext())
                {
                    db.Configuration.LazyLoadingEnabled = false;
                    db.Configuration.ProxyCreationEnabled = false;

                    return db.Promotions
                        .Include(p => p.Product)
                        .AsNoTracking()
                        .OrderByDescending(p => p.Id)
                        .ToList();
                }
            }
            catch
            {
                return new List<Promotions>();
            }
        }

        // READ - Get single promotion by ID
        public Promotions GetPromotionById(long id)
        {
            try
            {
                using (var db = new SupermarketContext())
                {
                    db.Configuration.LazyLoadingEnabled = false;
                    db.Configuration.ProxyCreationEnabled = false;

                    return db.Promotions
                        .Include(p => p.Product)
                        .FirstOrDefault(p => p.Id == id);
                }
            }
            catch
            {
                return null;
            }
        }

        // READ - Get currently active promotions
        public List<Promotions> GetActivePromotions()
        {
            try
            {
                using (var db = new SupermarketContext())
                {
                    db.Configuration.LazyLoadingEnabled = false;
                    db.Configuration.ProxyCreationEnabled = false;

                    DateTime today = DateTime.Today;
                    return db.Promotions
                        .Include(p => p.Product)
                        .AsNoTracking()
                        .Where(p => DbFunctions.TruncateTime(p.StartDate) <= today && DbFunctions.TruncateTime(p.EndDate) >= today)
                        .OrderByDescending(p => p.DiscountPercent)
                        .ToList();
                }
            }
            catch
            {
                return new List<Promotions>();
            }
        }

        // READ - Get active promotion for a specific product
        public Promotions GetActivePromotionByProductId(long productId)
        {
            try
            {
                using (var db = new SupermarketContext())
                {
                    db.Configuration.LazyLoadingEnabled = false;
                    db.Configuration.ProxyCreationEnabled = false;

                    DateTime today = DateTime.Today;
                    return db.Promotions
                        .Include(p => p.Product)
                        .FirstOrDefault(p => p.ProductId == productId && 
                                             DbFunctions.TruncateTime(p.StartDate) <= today && 
                                             DbFunctions.TruncateTime(p.EndDate) >= today);
                }
            }
            catch
            {
                return null;
            }
        }

        // READ - Get active promotion by product barcode
        public Promotions GetActivePromotionByBarcode(string barcode)
        {
            if (string.IsNullOrWhiteSpace(barcode)) return null;

            try
            {
                using (var db = new SupermarketContext())
                {
                    db.Configuration.LazyLoadingEnabled = false;
                    db.Configuration.ProxyCreationEnabled = false;

                    DateTime today = DateTime.Today;
                    return db.Promotions
                        .Include(p => p.Product)
                        .FirstOrDefault(p => p.Product.Barcode == barcode && 
                                             DbFunctions.TruncateTime(p.StartDate) <= today && 
                                             DbFunctions.TruncateTime(p.EndDate) >= today);
                }
            }
            catch
            {
                return null;
            }
        }

        // CREATE - Add a new promotion
        public bool AddPromotion(Promotions promo, out string errorMessage)
        {
            errorMessage = "";
            if (promo == null)
            {
                errorMessage = "Promotion details cannot be empty.";
                return false;
            }

            if (promo.ProductId <= 0)
            {
                errorMessage = "Please select a valid product for the promotion.";
                return false;
            }

            promo.PromotionName = promo.PromotionName.Trim();
            if (string.IsNullOrWhiteSpace(promo.PromotionName))
            {
                errorMessage = "Promotion name cannot be empty.";
                return false;
            }

            if (promo.DiscountPercent <= 0 || promo.DiscountPercent > 100)
            {
                errorMessage = "Discount percentage must be between 0.01% and 100%.";
                return false;
            }

            if (promo.EndDate.Date < promo.StartDate.Date)
            {
                errorMessage = "End date cannot be earlier than start date.";
                return false;
            }

            try
            {
                using (var db = new SupermarketContext())
                {
                    promo.CreatedAt = DateTime.Now;
                    promo.Product = null; // Do not re-insert the Product entity
                    db.Promotions.Add(promo);

                    // Synchronize the product's discount_percent in the products table
                    var product = db.Products.FirstOrDefault(p => p.Id == promo.ProductId);
                    if (product != null)
                    {
                        product.Discount_percent = promo.IsCurrentlyActive ? promo.DiscountPercent : 0.00m;
                    }

                    db.SaveChanges();
                    return true;
                }
            }
            catch (Exception ex)
            {
                errorMessage = ex.InnerException?.Message ?? ex.Message;
                return false;
            }
        }

        // UPDATE - Update an existing promotion
        public bool UpdatePromotion(Promotions promo, out string errorMessage)
        {
            errorMessage = "";
            if (promo == null)
            {
                errorMessage = "Promotion details cannot be empty.";
                return false;
            }

            if (promo.ProductId <= 0)
            {
                errorMessage = "Please select a valid product.";
                return false;
            }

            promo.PromotionName = promo.PromotionName.Trim();
            if (string.IsNullOrWhiteSpace(promo.PromotionName))
            {
                errorMessage = "Promotion name cannot be empty.";
                return false;
            }

            if (promo.DiscountPercent <= 0 || promo.DiscountPercent > 100)
            {
                errorMessage = "Discount percentage must be between 0.01% and 100%.";
                return false;
            }

            if (promo.EndDate.Date < promo.StartDate.Date)
            {
                errorMessage = "End date cannot be earlier than start date.";
                return false;
            }

            try
            {
                using (var db = new SupermarketContext())
                {
                    var existing = db.Promotions.FirstOrDefault(p => p.Id == promo.Id);
                    if (existing != null)
                    {
                        long oldProductId = existing.ProductId;

                        existing.ProductId = promo.ProductId;
                        existing.PromotionName = promo.PromotionName;
                        existing.DiscountPercent = promo.DiscountPercent;
                        existing.StartDate = promo.StartDate;
                        existing.EndDate = promo.EndDate;

                        // Synchronize product discount_percent
                        var product = db.Products.FirstOrDefault(p => p.Id == promo.ProductId);
                        if (product != null)
                        {
                            product.Discount_percent = promo.IsCurrentlyActive ? promo.DiscountPercent : 0.00m;
                        }

                        if (oldProductId != promo.ProductId)
                        {
                            var oldProd = db.Products.FirstOrDefault(p => p.Id == oldProductId);
                            if (oldProd != null)
                            {
                                oldProd.Discount_percent = 0.00m;
                            }
                        }

                        db.SaveChanges();
                        return true;
                    }
                    else
                    {
                        errorMessage = "Promotion record not found.";
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                errorMessage = ex.InnerException?.Message ?? ex.Message;
                return false;
            }
        }

        // DELETE - Delete promotion
        public bool DeletePromotion(long id, out string errorMessage)
        {
            errorMessage = "";
            try
            {
                using (var db = new SupermarketContext())
                {
                    var existing = db.Promotions.FirstOrDefault(p => p.Id == id);
                    if (existing != null)
                    {
                        long prodId = existing.ProductId;
                        db.Promotions.Remove(existing);

                        // Reset product discount_percent
                        var product = db.Products.FirstOrDefault(p => p.Id == prodId);
                        if (product != null)
                        {
                            product.Discount_percent = 0.00m;
                        }

                        db.SaveChanges();
                        return true;
                    }
                    else
                    {
                        errorMessage = "Promotion not found.";
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                errorMessage = ex.InnerException?.Message ?? ex.Message;
                return false;
            }
        }
    }
}

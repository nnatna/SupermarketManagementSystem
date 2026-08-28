using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Windows.Forms;
using Supermarket.Model;

namespace Supermarket.DAL
{
    internal class ProductsDAL
    {
        //Using Entity Framework

        // READ
        public List<Products> GetAllProducts()
        {
            try
            {
                using (var db = new SupermarketContext())
                {
                    db.Configuration.LazyLoadingEnabled = false;
                    db.Configuration.ProxyCreationEnabled = false;

                    var list = db.Products
                                 .Include(p => p.Categories)
                                 .Include(p => p.Units)
                                 .Include(p => p.Suppliers)
                                 .AsNoTracking()
                                 .ToList();

                    return list;
                }
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
                if (ex.InnerException != null)
                {
                    msg += "\nInner Exception: " + ex.InnerException.Message;
                    if (ex.InnerException.InnerException != null)
                    {
                        msg += "\n" + ex.InnerException.InnerException.Message;
                    }
                }
                MessageBox.Show("EF Query Error: " + msg, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return new List<Products>();
            }
        }

        //Get By ID
        public Products GetProductById(long productId)
        {
            try
            {
                using (var db = new SupermarketContext())
                {
                    db.Configuration.LazyLoadingEnabled = false;
                    db.Configuration.ProxyCreationEnabled = false;

                    return db.Products
                             .Include(p => p.Categories)
                             .Include(p => p.Units)
                             .Include(p => p.Suppliers)
                             .FirstOrDefault(p => p.Id == productId);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("EF Query Error: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        //Random Barcode
        public static string GenerateRandomBarcode()
        {
            Random rnd = new Random();
            return "885" + rnd.Next(100000000, 999999999).ToString();
        }

        //Create
        public bool AddProduct(Products product)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(product.Barcode))
                {
                    product.Barcode = GenerateRandomBarcode();
                }
                if (product.Image == null) product.Image = "";

                using (var db = new SupermarketContext())
                {
                    db.Products.Add(product);
                    return db.SaveChanges() > 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("EF Add Error: " + GetFullErrorMessage(ex), "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        //Update
        public bool UpdateProduct(Products product)
        {
            try
            {
                using (var db = new SupermarketContext())
                {
                    var existing = db.Products.FirstOrDefault(p => p.Id == product.Id);
                    if (existing != null)
                    {
                        existing.Name = product.Name;
                        if (!string.IsNullOrWhiteSpace(product.Barcode))
                        {
                            existing.Barcode = product.Barcode;
                        }
                        else if (string.IsNullOrWhiteSpace(existing.Barcode))
                        {
                            existing.Barcode = GenerateRandomBarcode();
                        }
                        existing.SupplierId = product.SupplierId;
                        existing.CategoryId = product.CategoryId;
                        existing.UnitId = product.UnitId;
                        existing.Cost_price = product.Cost_price;
                        existing.Selling_price = product.Selling_price;
                        existing.Stock_quantity = product.Stock_quantity;
                        existing.Stock_alert_level = product.Stock_alert_level;
                        existing.Discount_percent = product.Discount_percent;
                        existing.Image = product.Image ?? "";

                        db.SaveChanges();
                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("EF Update Error: " + GetFullErrorMessage(ex), "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return false;
        }

        //Get Message 
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

        // DELETE
        public bool DeleteProduct(long productId)
        {
            try
            {
                using (var db = new SupermarketContext())
                {
                    var product = db.Products.FirstOrDefault(p => p.Id == productId);
                    if (product != null)
                    {
                        db.Products.Remove(product);
                        return db.SaveChanges() > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("EF Delete Error: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return false;
        }

        //Get Categroy
        public List<Categories> GetAllCategories()
        {
            try
            {
                using (var db = new SupermarketContext())
                {
                    return db.Categories.AsNoTracking().ToList();
                }
            }
            catch
            {
                return new List<Categories>();
            }
        }

        //Get Ubit 
        public List<Units> GetAllUnits()
        {
            try
            {
                using (var db = new SupermarketContext())
                {
                    return db.Units.AsNoTracking().ToList();
                }
            }
            catch
            {
                return new List<Units>();
            }
        }

        //Get Suppliers
        public List<Suppliers> GetAllSuppliers()
        {
            try
            {
                using (var db = new SupermarketContext())
                {
                    return db.Suppliers.AsNoTracking().ToList();
                }
            }
            catch
            {
                return new List<Suppliers>();
            }
        }
    }
}


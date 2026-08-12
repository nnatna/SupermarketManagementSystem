using Supermarket.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Windows.Forms;

namespace Supermarket.DAL
{
    internal class CategoriesDAL
    {
        // Using Entity Framework

        // READ - Get all categories
        public List<Categories> GetAllCategories()
        {
            try
            {
                using (var db = new SupermarketContext())
                {
                    db.Configuration.LazyLoadingEnabled = false;
                    db.Configuration.ProxyCreationEnabled = false;
                    return db.Categories.AsNoTracking().ToList();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("EF Query Error: " + GetFullErrorMessage(ex), "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return new List<Categories>();
            }
        }

        // READ - Get category by ID
        public Categories GetCategoryById(int categoryId)
        {
            try
            {
                using (var db = new SupermarketContext())
                {
                    db.Configuration.LazyLoadingEnabled = false;
                    db.Configuration.ProxyCreationEnabled = false;
                    return db.Categories.FirstOrDefault(c => c.CategoryId == categoryId);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("EF Query Error: " + GetFullErrorMessage(ex), "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        // CREATE - Add a new category
        public bool AddCategory(Categories category)
        {
            try
            {
                using (var db = new SupermarketContext())
                {
                    db.Categories.Add(category);
                    return db.SaveChanges() > 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("EF Add Error: " + GetFullErrorMessage(ex), "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        // UPDATE - Update existing category
        public bool UpdateCategory(Categories category)
        {
            try
            {
                using (var db = new SupermarketContext())
                {
                    var existing = db.Categories.FirstOrDefault(c => c.CategoryId == category.CategoryId);
                    if (existing != null)
                    {
                        existing.CategoryName = category.CategoryName;
                        existing.Description = category.Description;
                        return db.SaveChanges() > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("EF Update Error: " + GetFullErrorMessage(ex), "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return false;
        }

        // DELETE - Delete category by ID
        public bool DeleteCategory(int categoryId)
        {
            try
            {
                using (var db = new SupermarketContext())
                {
                    var category = db.Categories.FirstOrDefault(c => c.CategoryId == categoryId);
                    if (category != null)
                    {
                        db.Categories.Remove(category);
                        return db.SaveChanges() > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("EF Delete Error: " + GetFullErrorMessage(ex), "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return false;
        }

        // Helper to format full error messages with inner exceptions
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

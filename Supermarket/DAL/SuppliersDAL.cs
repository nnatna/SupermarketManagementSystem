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
    internal class SuppliersDAL
    {
        // READ - Get all suppliers
        public List<Suppliers> GetAllSuppliers()
        {
            try
            {
                using (var db = new SupermarketContext())
                {
                    db.Configuration.LazyLoadingEnabled = false;
                    db.Configuration.ProxyCreationEnabled = false;
                    return db.Suppliers.AsNoTracking().ToList();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("EF Query Error: " + GetFullErrorMessage(ex), "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return new List<Suppliers>();
            }
        }

        // READ - Get supplier by ID
        public Suppliers GetSupplierById(long supplierId)
        {
            try
            {
                using (var db = new SupermarketContext())
                {
                    db.Configuration.LazyLoadingEnabled = false;
                    db.Configuration.ProxyCreationEnabled = false;
                    return db.Suppliers.FirstOrDefault(s => s.SupplierId == supplierId);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("EF Query Error: " + GetFullErrorMessage(ex), "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        // CREATE - Add a new supplier
        public bool AddSupplier(Suppliers supplier)
        {
            try
            {
                using (var db = new SupermarketContext())
                {
                    db.Suppliers.Add(supplier);
                    return db.SaveChanges() > 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("EF Add Error: " + GetFullErrorMessage(ex), "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        // UPDATE - Update existing supplier
        public bool UpdateSupplier(Suppliers supplier)
        {
            try
            {
                using (var db = new SupermarketContext())
                {
                    var existing = db.Suppliers.FirstOrDefault(s => s.SupplierId == supplier.SupplierId);
                    if (existing != null)
                    {
                        existing.CompanyName = supplier.CompanyName;
                        existing.ContactName = supplier.ContactName;
                        existing.Phone = supplier.Phone;
                        existing.Email = supplier.Email;
                        existing.Address = supplier.Address;
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

        // DELETE - Delete supplier by ID
        public bool DeleteSupplier(long supplierId)
        {
            try
            {
                using (var db = new SupermarketContext())
                {
                    var supplier = db.Suppliers.FirstOrDefault(s => s.SupplierId == supplierId);
                    if (supplier != null)
                    {
                        db.Suppliers.Remove(supplier);
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

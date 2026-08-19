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
    internal class SaleDetailDAL
    {
        public List<vw_SaleHistory> Getvw_SaleHistory()
        {
            try
            {
                using (var db = new SupermarketContext())
                {
                    // បិទ Lazy Loading ដើម្បីឱ្យការទាញទិន្នន័យកាន់តែលឿន
                    db.Configuration.LazyLoadingEnabled = false;
                    db.Configuration.ProxyCreationEnabled = false;

                    // ទាញទិន្នន័យពី View ផ្ទាល់តែម្ដង
                    var list = db.vw_SaleHistory
                                 .AsNoTracking() // ប្រើ AsNoTracking ព្រោះយើងគ្រាន់តែ Read ទិន្នន័យប៉ុណ្ណោះ (មិន Update)
                                 .OrderByDescending(s => s.sale_date) // តម្រៀបវិក្កយបត្រពីថ្មីទៅចាស់
                                 .ToList();

                    return list;
                }
            }
            catch (Exception ex)
            {
                // ប្រើប្រាស់ GetFullErrorMessage ដែលអ្នកមានស្រាប់ក្នុង SalesDAL
                string errorMessage = GetFullErrorMessage(ex);
                MessageBox.Show("EF Query Error: \n" + errorMessage, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return new List<vw_SaleHistory>(); // Return List ទទេនៅពេលមានបញ្ហា
            }
        }

        // Get details by Sale ID
        public List<SalesDetails> GetSaleDetailsBySaleId(long saleId)
        {
            try
            {
                using (var db = new SupermarketContext())
                {
                    db.Configuration.LazyLoadingEnabled = false;
                    db.Configuration.ProxyCreationEnabled = false;

                    return db.SalesDetails
                             .Include(d => d.Products)
                             .AsNoTracking()
                             .Where(d => d.Sale_id == saleId)
                             .ToList();
                }
            }
            catch (Exception ex)
            {
                string errorMessage = GetFullErrorMessage(ex);
                MessageBox.Show("EF Query Error: \n" + errorMessage, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return new List<SalesDetails>();
            }
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

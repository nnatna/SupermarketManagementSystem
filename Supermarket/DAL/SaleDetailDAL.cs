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
                    //Lazy Loading
                    db.Configuration.LazyLoadingEnabled = false;
                    db.Configuration.ProxyCreationEnabled = false;

                    //View
                    var list = db.vw_SaleHistory
                                 .AsNoTracking()
                                 .OrderByDescending(s => s.sale_date)
                                 .ToList();

                    return list;
                }
            }
            catch (Exception ex)
            {
                //GetFullErrorMessage
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

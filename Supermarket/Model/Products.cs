using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supermarket.Model
{
    internal class Products
    {
        public int ProductId { get; set; }
        public string Barcode { get; set; } = "";
        public string Name { get; set; } = "";

        //public int CategoryId
        //{
        //    get { return Categories?.CategoryId ?? 0; }
        //}

        public string CategoryName
        {
            get { return Categories?.CategoryName ?? ""; }
        }

        //public int UnitId
        //{
        //    get { return Units?.UnitId ?? 0; }
        //}

        public string UnitName
        {
            get { return Units?.UnitName ?? ""; }
        }

        public decimal Cost_price { get; set; }
        public decimal Selling_price { get; set; }
        public int Stock_quantity { get; set; }
        public int Stock_alert_level { get; set; }
        public string Image { get; set; } = "";

        [Browsable(false)]
        public Categories Categories { get; set; } = new Categories();

        [Browsable(false)]
        public Units Units { get; set; } = new Units();
    }
}

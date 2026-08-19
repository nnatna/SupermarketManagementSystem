using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Supermarket.Model
{
    [Table("vw_SaleHistory")]
    public class vw_SaleHistory
    {
        [Key]
        [Column("SaleHistoryID")]
        public long SaleHistoryID { get; set; }

        [NotMapped]
        public long Id => SaleHistoryID;

        [Column("sale_id")]
        public long sale_id { get; set; }

        [NotMapped]
        public long SaleId => sale_id;

        [Column("invoice_number")]
        public string invoice_number { get; set; }

        [NotMapped]
        public string InvoiceNumber => invoice_number;

        [NotMapped]
        public string Invoice_Number => invoice_number;

        [Column("sale_date")]
        public DateTime? sale_date { get; set; }

        [NotMapped]
        public DateTime? SaleDate => sale_date;

        [Column("product_id")]
        public long? product_id { get; set; }

        [NotMapped]
        public long? ProductId => product_id;

        [Column("product_name")]
        public string product_name { get; set; }

        [NotMapped]
        public string ProductName => product_name;

        [Column("quantity")]
        public int? quantity { get; set; }

        [NotMapped]
        public int Quantity => quantity ?? 0;

        [NotMapped]
        public int Quatity => quantity ?? 0;

        [Column("unit_price")]
        public decimal? unit_price { get; set; }

        [NotMapped]
        public decimal UnitPrice => unit_price ?? 0m;

        [NotMapped]
        public decimal Unit_Price => unit_price ?? 0m;

        [Column("subtotal")]
        public decimal? subtotal { get; set; }

        [NotMapped]
        public decimal Subtotal => subtotal ?? 0m;

        [NotMapped]
        public decimal Discount => 0m;

        [NotMapped]
        public decimal Total => subtotal ?? 0m;

        [Column("payment_method")]
        public string payment_method { get; set; }

        [NotMapped]
        public string PaymentMethod => payment_method;

        [Column("status")]
        public string status { get; set; }

        [NotMapped]
        public string Status => status;
    }
}

using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Supermarket.Model
{
    [Table("sale_details")]
    public class SalesDetails
    {
        [Key]
        [Column("id")]
        public long Id { get; set; }

        [Column("sale_id")]
        public long Sale_id { get; set; }

        [Column("invoice_number")]
        public string Invoice_number { get; set; } = "";

        [NotMapped]
        public string InvoiceNumber => Invoice_number;

        [Column("product_id")]
        public long Product_id { get; set; }

        [Column("quantity")]
        public int Quantity { get; set; }

        [Column("unit_price")]
        public decimal Unit_price { get; set; }

        [Column("subtotal")]
        public decimal Subtotal { get; set; }

        // Navigation Properties
        [ForeignKey("Sale_id")]
        public virtual Sales Sales { get; set; }

        [ForeignKey("Product_id")]
        public virtual Products Products { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Supermarket.Model
{
    [Table("sales")]
    public class Sales
    {
        [Key]
        [Column("id")]
        public long Id { get; set; }

        // Moved to sale_details table in database; kept unmapped here for convenient business logic / UI usage
        [NotMapped]
        public string Invoice_number { get; set; } = "";

        [NotMapped]
        public string InvoiceNumber => Invoice_number;

        [Column("customer_id")]
        public long? Customer_id { get; set; }

        [Column("user_id")]
        public long User_id { get; set; } = 1; // Default system user

        [Column("promotion_id")]
        public long? Promotion_id { get; set; }

        [Column("subtotal")]
        public decimal? Subtotal { get; set; }

        [Column("discount_amount")]
        public decimal? Discount_amount { get; set; }

        [Column("grand_total")]
        public decimal? Grand_total { get; set; }

        [Required]
        [Column("payment_method")]
        public string Payment_method { get; set; } = "Cash";

        [Column("sale_date")]
        public DateTime? Sale_date { get; set; } = DateTime.Now;

        [Column("status")]
        public string Status { get; set; }

        // Navigation Properties
        public virtual ICollection<SalesDetails> SaleDetails { get; set; } = new List<SalesDetails>();
    }
}

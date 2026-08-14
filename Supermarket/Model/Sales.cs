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

        [Required]
        [Column("invoice_number")]
        public string Invoice_number { get; set; } = "";

        [Column("customer_id")]
        public long? Customer_id { get; set; }

        [Column("user_id")]
        public long User_id { get; set; } = 1; // Default system user

        [Column("promotion_id")]
        public long? Promotion_id { get; set; }

        [Column("subtotal")]
        public decimal Subtotal { get; set; }

        [Column("discount_amount")]
        public decimal Discount_amount { get; set; }

        [Column("grand_total")]
        public decimal Grand_total { get; set; }

        [Column("paid_amount")]
        public decimal Paid_amount { get; set; }

        [Column("change_amount")]
        public decimal Change_amount { get; set; }

        [Required]
        [Column("payment_method")]
        public string Payment_method { get; set; } = "cash";

        [Column("sale_date")]
        public DateTime Sale_date { get; set; } = DateTime.Now;

        // Navigation Properties
        public virtual ICollection<SalesDetails> SaleDetails { get; set; } = new List<SalesDetails>();
    }
}


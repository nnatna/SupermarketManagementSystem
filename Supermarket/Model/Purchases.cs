using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Supermarket.Model
{
    [Table("purchases")]
    public class Purchases
    {
        [Key]
        [Column("id")]
        public long PurchaseId { get; set; }

        [NotMapped]
        public long Id => PurchaseId;

        [Required]
        [Column("purchase_number")]
        public string PurchaseNumber { get; set; }

        [Column("supplier_id")]
        public long SupplierId { get; set; }

        [Column("user_id")]
        public long UserId { get; set; }

        [Column("total_amount")]
        public decimal? TotalAmount { get; set; }

        [Column("status")]
        public string Status { get; set; } = "pending";

        [Column("purchase_date")]
        public DateTime PurchaseDate { get; set; } = DateTime.Now;

        public virtual ICollection<PurchaseDetails> PurchaseDetails { get; set; } = new List<PurchaseDetails>();
    }
}

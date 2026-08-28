using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Supermarket.Model
{
    [Table("purchase_details")]
    public class PurchaseDetails
    {
        [Key]
        [Column("id")]
        public long PurchaseDetailId { get; set; }

        [NotMapped]
        public long Id => PurchaseDetailId;

        [Column("purchase_id")]
        public long PurchaseId { get; set; }

        [Column("product_id")]
        public long ProductId { get; set; }

        [Column("quantity")]
        public int Quantity { get; set; }

        [Column("unit_cost")]
        public decimal UnitCost { get; set; }

        [Column("subtotal")]
        public decimal Subtotal { get; set; }

        [ForeignKey("PurchaseId")]
        public virtual Purchases Purchase { get; set; }

        [ForeignKey("ProductId")]
        public virtual Products Product { get; set; }
    }
}

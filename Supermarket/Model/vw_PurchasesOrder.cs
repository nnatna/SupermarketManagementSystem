using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Supermarket.Model
{
    [Table("vw_PurchasesOrder")]
    public class vw_PurchasesOrder
    {
        [Key]
        [Column("purchase_detail_id")]
        public long PurchaseDetailID { get; set; }

        [NotMapped]
        public long Id => PurchaseDetailID;

        [Column("purchase_id")]
        public long PurchaseId { get; set; }

        [Column("purchase_number")]
        public string PurchaseNumber { get; set; }

        [Column("purchase_date")]
        public DateTime PurchaseDate { get; set; }

        [Column("supplier_id")]
        public long SupplierId { get; set; }

        [Column("supplier_name")]
        public string SupplierName { get; set; }

        [Column("contact_name")]
        public string ContactName { get; set; }

        [Column("supplier_phone")]
        public string SupplierPhone { get; set; }

        [Column("user_id")]
        public long UserId { get; set; }

        [Column("username")]
        public string Username { get; set; }

        [Column("product_id")]
        public long ProductId { get; set; }

        [Column("product_name")]
        public string ProductName { get; set; }

        [Column("barcode")]
        public string Barcode { get; set; }

        [Column("quantity")]
        public int Quantity { get; set; }

        [Column("unit_cost")]
        public decimal UnitCost { get; set; }

        [Column("subtotal")]
        public decimal Subtotal { get; set; }

        [Column("total_amount")]
        public decimal TotalAmount { get; set; }

        [Column("status")]
        public string Status { get; set; }
    }
}

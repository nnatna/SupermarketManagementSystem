using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Supermarket.Model
{
    [Table("promotions")]
    public class Promotions
    {
        [Key]
        [Column("id")]
        public long Id { get; set; }

        [Required]
        [Column("product_id")]
        public long ProductId { get; set; }

        [Required]
        [Column("promotion_name")]
        [MaxLength(150)]
        public string PromotionName { get; set; } = "";

        [Column("discount_percent")]
        public decimal DiscountPercent { get; set; } = 0.00m;

        [Column("start_date")]
        public DateTime StartDate { get; set; } = DateTime.Today;

        [Column("end_date")]
        public DateTime EndDate { get; set; } = DateTime.Today.AddDays(30);

        [Column("created_at")]
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        // Navigation Property
        [ForeignKey("ProductId")]
        public virtual Products Product { get; set; }

        // UI & POS Helper Properties
        [NotMapped]
        public string ProductName => Product?.Name ?? "";

        [NotMapped]
        public string Barcode => Product?.Barcode ?? "";

        [NotMapped]
        public decimal OriginalPrice => Product?.Selling_price ?? 0.00m;

        [NotMapped]
        public decimal DiscountedPrice => Product != null 
            ? Math.Round(Product.Selling_price * (1.0m - (DiscountPercent / 100.0m)), 2) 
            : 0.00m;

        [NotMapped]
        public string FormattedDiscount => $"{DiscountPercent:0.##}%";

        [NotMapped]
        public string DateRangeText => $"{StartDate:yyyy-MM-dd} ~ {EndDate:yyyy-MM-dd}";

        [NotMapped]
        public string Status
        {
            get
            {
                DateTime today = DateTime.Today;
                if (today < StartDate.Date) return "Upcoming";
                if (today > EndDate.Date) return "Expired";
                return "Active";
            }
        }

        [NotMapped]
        public bool IsCurrentlyActive => DateTime.Today >= StartDate.Date && DateTime.Today <= EndDate.Date;
    }
}

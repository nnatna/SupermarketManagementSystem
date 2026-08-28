using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Supermarket.Model
{
    [Table("stock_adjustments")]
    public class StockAdjustments
    {
        [Key]
        [Column("id")]
        public long Id { get; set; }

        [NotMapped]
        public long StockId => Id;

        [Column("product_id")]
        public long ProductId { get; set; }

        [NotMapped]
        public long product_id
        {
            get => ProductId;
            set => ProductId = value;
        }

        [Column("user_id")]
        public long UserId { get; set; } = 1;

        [NotMapped]
        public long user_id
        {
            get => UserId;
            set => UserId = value;
        }

        [Required]
        [Column("type")]
        public string Type { get; set; } = "addition";

        [NotMapped]
        public string type
        {
            get => Type;
            set => Type = value;
        }

        [NotMapped]
        public int CurrentStock { get; set; }

        [NotMapped]
        public int current_stock 
        { 
            get => CurrentStock; 
            set => CurrentStock = value; 
        }


        [Column("quantity")]
        public int Quantity { get; set; }

        [NotMapped]
        public int quantity
        {
            get => Quantity;
            set => Quantity = value;
        }

        [Column("reason")]
        public string Reason { get; set; } = string.Empty;

        [NotMapped]
        public string reason
        {
            get => Reason;
            set => Reason = value;
        }

        [Column("adjusted_at")]
        public DateTime? AdjustedAt { get; set; } = DateTime.Now;

        [NotMapped]
        public DateTime? Adjusted_at
        {
            get => AdjustedAt;
            set => AdjustedAt = value;
        }

        [NotMapped]
        public DateTime? adjusted_at
        {
            get => AdjustedAt;
            set => AdjustedAt = value;
        }

        [Column("status")]
        public string Status { get; set; } = "Pending";

        [NotMapped]
        public string status
        {
            get => Status;
            set => Status = value;
        }

        // Navigation Properties for Entity Framework
        [ForeignKey("ProductId")]
        public virtual Products Products { get; set; }
    }

    [Table("vw_Stock_adjustments")]
    public class vw_Stock_adjustments
    {
        [Key]
        [Column("StockId")]
        public long StockID { get; set; }

        [NotMapped]
        public long StockId => StockID;

        [NotMapped]
        public long Id => StockID;

        [Column("product_id")]
        public long? ProductID { get; set; }

        [NotMapped]
        public long? ProductId => ProductID;

        [NotMapped]
        public long? product_id => ProductID;

        [Column("product_name")]
        public string ProductName { get; set; } = string.Empty;

        [NotMapped]
        public string product_name => ProductName;

        [Column("current_stock")]
        public int? CurrentStock { get; set; }

        [NotMapped]
        public int? current_stock => CurrentStock;

        [NotMapped]
        public int? stock_quantity => CurrentStock;

        [Column("user_id")]
        public long? UserID { get; set; }

        [NotMapped]
        public long? UserId => UserID;

        [NotMapped]
        public long? user_id => UserID;

        [Column("username")]
        public string Username { get; set; } = string.Empty;

        [NotMapped]
        public string username => Username;

        [Column("type")]
        public string Type { get; set; } = string.Empty;

        [NotMapped]
        public string type => Type;

        [Column("quantity")]
        public int? Quantity { get; set; }

        [NotMapped]
        public int? quantity => Quantity;

        [Column("reason")]
        public string Reason { get; set; } = string.Empty;

        [NotMapped]
        public string reason => Reason;

        [Column("adjusted_at")]
        public DateTime? AdjustedAt { get; set; }

        [NotMapped]
        public DateTime? adjusted_at => AdjustedAt;

        [NotMapped]
        public DateTime? Adjusted_at => AdjustedAt;

        [NotMapped]
        public DateTime? transaction_date => AdjustedAt;

        [NotMapped]
        public DateTime? sale_date => AdjustedAt;

        [Column("status")]
        public string Status { get; set; } = "Pending";

        [NotMapped]
        public string status => Status;
    }
}

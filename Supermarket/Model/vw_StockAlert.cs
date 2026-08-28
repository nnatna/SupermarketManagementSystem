using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supermarket.Model
{
    [Table("vw_StockAlert")]
    public class vw_StockAlert
    {
        [Key]
        [Column("PartID")]
        public long PartID { get; set; }

        [NotMapped]
        public long Id => PartID;

        [Column("Barcode")]
        public string Barcode { get; set; } = string.Empty;

        [Column("ProductName")]
        public string ProductName { get; set; } = string.Empty;

        [NotMapped]
        public string name => ProductName;

        [Column("CategoryID")]
        public int? CategoryID { get; set; }

        [NotMapped]
        public int? CategoryId => CategoryID;

        [NotMapped]
        public int? category_id => CategoryID;

        [Column("CategoryName")]
        public string CategoryName { get; set; } = string.Empty;

        [Column("CurrentStock")]
        public int CurrentStock { get; set; }

        [NotMapped]
        public int stock_quantity => CurrentStock;

        [Column("AlertQty")]
        public int AlertQty { get; set; }

        [NotMapped]
        public int stock_alert_level => AlertQty;

        [Column("LastRestocked")]
        public string LastRestocked { get; set; } = string.Empty;

        [Column("StatusText")]
        public string StatusText { get; set; } = string.Empty;
    }
    }

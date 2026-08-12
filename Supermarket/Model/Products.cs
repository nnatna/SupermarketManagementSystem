using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Drawing;
using System.IO;

namespace Supermarket.Model
{
    [Table("products")]
    internal class Products
    {
        [Key]
        [Column("id")]
        public long Id { get; set; }

        [Column("barcode")]
        public string Barcode { get; set; } = "";

        [Required]
        [Column("name")]
        public string Name { get; set; } = "";

        [Browsable(false)]
        [Column("category_id")]
        public int? CategoryId { get; set; }

        [Browsable(false)]
        [Column("unit_id")]
        public int? UnitId { get; set; }

        [Column("cost_price")]
        public decimal Cost_price { get; set; }

        [Column("selling_price")]
        public decimal Selling_price { get; set; }

        [Column("stock_quantity")]
        public int Stock_quantity { get; set; }

        [Column("stock_alert_level")]
        public int Stock_alert_level { get; set; }

        [Browsable(false)]
        [Column("image")]
        public string Image { get; set; } = "";

        // Navigation Properties for Entity Framework
        [Browsable(false)]
        [ForeignKey("CategoryId")]
        public virtual Categories Categories { get; set; }

        [Browsable(false)]
        [ForeignKey("UnitId")]
        public virtual Units Units { get; set; }

        [NotMapped]
        public string Category => Categories?.CategoryName ?? "";

        [NotMapped]
        public string Unit => Units?.UnitName ?? "";

        [NotMapped]
        [DisplayName("Image")]
        public Image ProductImage
        {
            get
            {
                if (!string.IsNullOrWhiteSpace(Image))
                {
                    try
                    {
                        string fullPath = Image;
                        if (!Path.IsPathRooted(fullPath))
                        {
                            fullPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, Image);
                        }

                        if (File.Exists(fullPath))
                        {
                            using (var img = System.Drawing.Image.FromFile(fullPath))
                            {
                                return new Bitmap(img);
                            }
                        }
                    }
                    catch
                    {
                        // Fallback on error loading file
                    }
                }
                return GetDefaultImage();
            }
        }

        private static Image GetDefaultImage()
        {
            Bitmap bmp = new Bitmap(50, 50);
            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.Clear(Color.FromArgb(235, 238, 242));
                using (Font font = new Font("Segoe UI", 8, FontStyle.Bold))
                using (Brush brush = new SolidBrush(Color.Gray))
                {
                    g.DrawString("NO IMAGE", font, brush, 0, 18);
                }
            }
            return bmp;
        }
    }
}

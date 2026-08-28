using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Drawing;
using System.IO;

namespace Supermarket.Model
{
    [Table("employees")]
    public class Employees
    {
        [Key]
        [Column("id")]
        public long Id { get; set; }

        [Required]
        [Column("fullname")]
        [MaxLength(500)]
        public string FullName { get; set; } = "";

        [Column("gender")]
        [MaxLength(10)]
        public string Gender { get; set; } = "";

        [Column("phone")]
        [MaxLength(20)]
        public string Phone { get; set; } = "";

        [Column("email")]
        [MaxLength(100)]
        public string Email { get; set; } = "";

        [Column("position")]
        [MaxLength(50)]
        public string Position { get; set; } = "";

        [Column("salary")]
        public decimal? Salary { get; set; }

        [Column("hire_date")]
        public DateTime? HireDate { get; set; }

        [Browsable(false)]
        [Column("photo_path")]
        [MaxLength(500)]
        public string Photo_path { get; set; } = "";

        [NotMapped]
        [Browsable(false)]
        public string PhotoPath
        {
            get => Photo_path;
            set => Photo_path = value ?? "";
        }

        [Column("created_at")]
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        [NotMapped]
        [DisplayName("Image")]
        public Image EmployeeImage
        {
            get
            {
                if (!string.IsNullOrWhiteSpace(Photo_path))
                {
                    try
                    {
                        string fullPath = Photo_path;
                        if (!Path.IsPathRooted(fullPath))
                        {
                            fullPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, Photo_path);
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

        [NotMapped]
        [DisplayName("Photo")]
        public Image Photo => EmployeeImage;

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

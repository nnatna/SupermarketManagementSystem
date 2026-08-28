using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Drawing;
using System.IO;

namespace Supermarket.Model
{
    [Table("users")]
    public class Users
    {
        [Key]
        [Column("id")]
        public long Id { get; set; }

        [Browsable(false)]
        [Column("employee_id")]
        public long? EmployeeId { get; set; }

        [Browsable(false)]
        [Column("role_id")]
        public int RoleId { get; set; }

        [Required]
        [Column("username")]
        [MaxLength(50)]
        public string Username { get; set; } = "";

        [Required]
        [Browsable(false)]
        [Column("password")]
        [MaxLength(255)]
        public string Password { get; set; } = "";

        [Column("status")]
        [MaxLength(10)]
        public string Status { get; set; } = "active";

        [Column("created_at")]
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        // Navigation Properties for Entity Framework
        [Browsable(false)]
        [ForeignKey("EmployeeId")]
        public virtual Employees Employees { get; set; }

        [Browsable(false)]
        [ForeignKey("RoleId")]
        public virtual Roles Roles { get; set; }

        // NotMapped Helper Properties for Grid & UI Binding
        [NotMapped]
        public string EmployeeName => Employees?.FullName ?? "None";

        [NotMapped]
        public string RoleName => Roles?.Name ?? "";

        [NotMapped]
        [DisplayName("Image")]
        public Image UserImage
        {
            get
            {
                if (Employees != null && !string.IsNullOrWhiteSpace(Employees.Photo_path))
                {
                    try
                    {
                        string fullPath = Employees.Photo_path;
                        if (!Path.IsPathRooted(fullPath))
                        {
                            fullPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, fullPath);
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

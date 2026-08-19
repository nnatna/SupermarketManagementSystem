using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Supermarket.Model
{
    [Table("suppliers")]
    public class Suppliers
    {
        [Key]
        [Column("id")]
        public long Id { get; set; }

        [NotMapped]
        public long SupplierId => Id;

        [Required]
        [Column("company_name")]
        public string CompanyName { get; set; } = "";

        [Column("contact_name")]
        public string ContactName { get; set; } = "";

        [Column("phone")]
        public string Phone { get; set; } = "";

        [Column("email")]
        public string Email { get; set; } = "";

        [Column("address")]
        public string Address { get; set; } = "";

        [Column("created_at")]
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public virtual ICollection<Products> Products { get; set; } = new List<Products>();
    }
}

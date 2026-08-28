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
        public long SupplierId { get; set; }

        [NotMapped]
        public long Id => SupplierId;

        [NotMapped]
        public long id => SupplierId;

        [Required]
        [Column("company_name")]
        public string CompanyName { get; set; }

        [NotMapped]
        public string company_name => CompanyName;

        [Column("contact_name")]
        public string ContactName { get; set; }

        [NotMapped]
        public string contact_name => ContactName;

        [Column("phone")]
        public string Phone { get; set; }
        [NotMapped]
        public string phone => Phone;

        [Column("email")]
        public string Email { get; set; }

        [NotMapped]
        public string email => Email;

        [Column("address")]
        public string Address { get; set; }

        [NotMapped]
        public string address => Address;

        [Column("created_at")]
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        [NotMapped]
        public DateTime create_at => CreatedAt;

        public virtual ICollection<Products> Products { get; set; } = new List<Products>();


    }
}

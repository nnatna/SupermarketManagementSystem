using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supermarket.Model
{
    [Table("categories")]
    public class Categories
    {
        [Key]
        [Column("id")]
        public int CategoryId { get; set; }

        [Column("name")]
        public string CategoryName { get; set; } = string.Empty;

        [Column("description")]
        public string Description { get; set; } = string.Empty;

        public override string ToString()
        {
            return CategoryName;
        }
    }
}

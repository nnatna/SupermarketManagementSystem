using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supermarket.Model
{
    [Table("units")]
    public class Units
    {
        [Key]
        [Column("id")]
        public int UnitId { get; set; }

        [Column("name")]
        public string UnitName { get; set; } = string.Empty;

        [Column("short_name")]
        public string ShortName { get; set; } = string.Empty;

        public override string ToString()
        {
            return UnitName;
        }
    }
}

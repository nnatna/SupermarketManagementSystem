using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supermarket.Model
{
    internal class Units
    {
        public int UnitId { get; set; }
        public string UnitName { get; set; } = string.Empty;
        public string ShortName { get; set; } = string.Empty;

        public override string ToString()
        {
            return UnitName;
        }
    }
}

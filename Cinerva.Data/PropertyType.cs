using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinerva.Data
{
    public class PropertyType
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public ICollection<Property> Properties { get; set; }

    }
}

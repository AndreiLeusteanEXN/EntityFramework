using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinerva.Data
{
    public class PropertyFacility
    {
        public int PropertyId { get; set; }
        public int FeatureId { get; set; }
        public GeneralFeature GeneralFeature { get; set; }
        public Property Property { get; set; }
    }
}

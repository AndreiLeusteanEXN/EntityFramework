using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinerva.Data
{
    public class RoomFacility
    {
        public int RoomId { get; set; }
        public int FeatureId { get; set; }
        public RoomFeature RoomFeature { get; set; }
        public Room Room { get; set; }
    }
}

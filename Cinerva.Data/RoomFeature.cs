using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinerva.Data
{
    public class RoomFeature
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<RoomFacility> RoomFacilities { get; set; }
    }
}

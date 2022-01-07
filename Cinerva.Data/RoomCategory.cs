using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinerva.Data
{
    public class RoomCategory
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int BedsCount { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public ICollection<Room> Rooms { get; set; }
    }
}

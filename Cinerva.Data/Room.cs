using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinerva.Data
{
    public class Room
    {
        public int Id { get; set; }
        public int RoomCategoryId { get; set; }
        public int PropertyId { get; set; }
        public RoomCategory RoomCategory { get; set; }
        public Property Property { get; set; }
        public ICollection<RoomFacility> RoomFacilities { get; set; }
        public ICollection<Reservation> Reservations { get; set; }
        public ICollection<RoomReservation> RoomReservations { get; set; }


    }
}

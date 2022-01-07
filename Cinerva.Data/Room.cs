using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinerva.Data
{
    public class Room
    {
        public int Id { get; set; }
        [Column("RoomCategory")]
        public int RoomCategoryId { get; set; }
        public int PropertyId { get; set; }
        public RoomCategory RoomCategory { get; set; }
        public Property Property { get; set; }
        public IList<RoomFacility> RoomFacilities { get; set; }
        public IList<Reservation> Reservations { get; set; }
        public IList<RoomReservation> RoomReservations { get; set; }


    }
}

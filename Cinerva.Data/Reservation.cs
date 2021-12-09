using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinerva.Data
{
    public class Reservation
    {
        public int Id { get; set; }
        public DateTime CheckInDate { get; set; }
        public DateTime CheckOutDate { get; set; }
        public DateTime CancelDate { get; set; }
        public int Price { get; set; }
        public string PaymentMethod { get; set; }
        public bool PaymentStatus { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public ICollection<Room> Rooms { get; set; }
        public ICollection<RoomReservation> RoomReservations { get; set; }
    }
}

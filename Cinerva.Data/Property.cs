using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinerva.Data
{
    public class Property
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Rating { get; set; }
        public string Description { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public int TotalRooms { get; set; }
        public int NumberOfDayForRefunds { get; set; }
        public int CityId { get; set; }
        public int AdministratorId { get; set; }
        public int PropertyTypeId { get; set; }
        public City City { get; set; }
        public User User { get; set; }
        public IList<Room> Rooms { get; set; }
        public PropertyType PropertyType { get; set; }
        public IList<PropertyImage> PropertyImages { get; set; }
        public IList<PropertyFacility> PropertyFacilities { get; set; }
        public IList<Review> Reviews { get; set; }
    }
}

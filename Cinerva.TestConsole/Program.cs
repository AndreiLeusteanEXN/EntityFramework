using Cinerva.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace Cinerva.TestConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            var cinerva = new CinervaDbContext();

            var users = cinerva.Users;

            var properties = cinerva.Properties;

            var roomCategories = cinerva.RoomCategories;

            var rooms = cinerva.Rooms;

            var reservations = cinerva.Reservations;

            var roomReservations = cinerva.RoomReservations;



            //-----join example
            //var reviews = cinerva.Reviews.Include(u => u.User).Include(u => u.Property);

            //foreach (var review in reviews)
            //{
            //    Console.WriteLine($"{review.User.FirstName} {review.User.LastName} about {review.Property.Name}:\n{review.Description}\n\n");
            //}
            //-----end of join example


            //foreach (var admin in admins)
            //{
            //    foreach (var property in admin.Properties)
            //    {
            //        Console.WriteLine($"{admin.FirstName} {admin.LastName} is admin of {property.Name}");
            //    }

            //}

            //ex 2
            //var properties = cinerva.Properties.Where(p => p.City.Name == "Iasi");

            //foreach (var property in properties)
            //{
            //    Console.WriteLine($"{property.Name} {property.Description} {property.Description} {property.TotalRooms}");
            //}


            //ex 3
            //var reservations = cinerva.Reservations.Include(r => r.User).Where(r => r.PaymentStatus == true);

            //var ex3 = users.Include(u => u.Reservations);

            //foreach (var user in ex3)
            //{
            //    foreach (var reservation in user.Reservations)
            //    {
            //        if (reservation.PaymentStatus == true)
            //        {
            //            Console.WriteLine($"{user.FirstName} {user.LastName} {user.Email} {user.Phone}");
            //            break;
            //        }
            //    }
            //}

            //ex4
            //sounds good, doesn't work

            //var ex4 = properties.Include(p => p.User).Include(p => p.City).Include(p => p.PropertyType)
            //                    .Where(p => p.City.Name == "Brasov" && p.PropertyType.Type == "House")
            //                    .OrderBy(p => p.User.FirstName).ThenBy(p => p.User.LastName).ToList();

            //foreach (var property in properties)
            //{
            //    Console.WriteLine($"{property.User.FirstName}, {property.User.LastName}");
            //}


            //ex5
            //            SELECT rc.Name, rc.Price, p.Id, p.Name
            //FROM Rooms r

            //    INNER JOIN Properties p on p.id = r.PropertyId

            //    INNER JOIN RoomCategories rc on rc.id = r.RoomCategory

            //    INNER JOIN Cities c on c.Id = p.CityId

            //    INNER JOIN Countries ctr on c.CountryId = ctr.Id

            //    INNER JOIN PropertyTypes pt on p.PropertyTypeId = pt.Id
            //WHERE p.Name = 'InterContinental'

            //    AND ctr.Name = 'Romania'

            //    AND pt.Type = 'Hotel';

            //var ex5 = properties.Include(p => p.PropertyType).Include(p => p.)
            //            .Include(p => p.City).ThenInclude(c => c.Country);

            //var ex5 = rooms.Include(r => r.RoomCategory).Include(r => r.Property).ThenInclude(p => p.City).ThenInclude(c => c.Country).Include(p => p.Property.PropertyType)
            //               .Where(x => x.Property.Name == "InterContinental" &&
            //                           x.Property.City.Country.Name == "Romania" &&
            //                           x.Property.PropertyType.Type == "Hotel");
            //foreach (var rc in ex5)
            //{
            //    Console.WriteLine($"{rc.RoomCategory.Name} {rc.RoomCategory.Price} {rc.Property.Name}");
            //}


            //props in Romania available today

            //SELECT TOP 5 p.Id, p.Name, COUNT(rsv.Id)--rsv.Id, rsv.CheckInDate, rsv.CheckOutDate, rsv.CancelDate
            //FROM Reservations rsv

            //    INNER JOIN RoomReservations rr ON rsv.id = rr.ReservationId

            //    INNER JOIN Rooms r ON rr.RoomId = r.Id

            //    INNER JOIN Properties p ON p.Id = r.PropertyId

            //    INNER JOIN Cities ct ON p.CityId = ct.Id

            //    INNER JOIN Countries ctr ON ct.CountryId = ctr.Id
            //WHERE(month(rsv.CheckoutDate) = 11 or month(rsv.CheckInDate) = 11)

            //    AND rsv.CancelDate = NULL

            //        OR(year(rsv.CancelDate) = 2021

            //        AND rsv.CancelDate >= rsv.CheckInDate)

            //    AND month(rsv.CancelDate)= 11

            //    AND ctr.Name = 'Algeria'
            //GROUP BY p.Id, p.Name
            //ORDER BY COUNT(rsv.Id) DESC;
            //////////////////////////////////////////REDOOOOOOOOOOOOOOOOOOOOOOOOOOO
            //var ex6 = reservations.Include(rsv => rsv.RoomReservations).Include(rsv => rsv.Rooms).ThenInclude(r => r.Property).ThenInclude(p => p.City).ThenInclude(ct => ct.Country)
            //                      .Where(rsv => rsv.CheckInDate >= new DateTime(2021, 11, 1) ||
            //                                    rsv.CheckOutDate <= new DateTime(2021, 11, 1) ||
            //                                    rsv.CheckInDate < new DateTime(2021, 11, 1) &&
            //                                        rsv.CheckOutDate > new DateTime(2021, 11, 1) &&
            //                                        (
            //                                            (rsv.CancelDate < rsv.CheckInDate || rsv.CancelDate==null) ||
            //                                            rsv.CancelDate < rsv.CheckInDate && rsv.CancelDate >= new DateTime(2021, 11, 1)
            //                                        )
            //                            );
            //foreach (var rsv in ex6)
            //{
            //    Console.WriteLine($"{rsv.Rooms.Property.}");
            //}              REDO



            //ex 7 sounds good, doesn't work

            //var ex7 = properties.Include(p => p.PropertyFacilities).ThenInclude(pf => pf.GeneralFeature).Include(p => p.Rooms).ThenInclude(r => r.Reservations)
            //                    .Where(p => p.PropertyFacilities.GeneralFeature.Name == "Swimming Pool" &&
            //                                    (p.Rooms.Reservations.CheckOutDate < DateTime.Now ||
            //                                    p.Rooms.Reservations.CancelDate < DateTime.Now && p.Rooms.Reservations.CancelDate > p.Rooms.Reservations.CheckInDate ||
            //                                    p.Rooms.Reservations.CheckInDate > DateTime.Now);
            //foreach (var prop in ex7)
            //{
            //    Console.WriteLine($"{prop.Name}");
            //}


            //SELECT distinct p.Name, count(p.Name) --, ctr.Id
            //FROM Properties p
            //    INNER JOIN Cities ct ON ct.Id = p.CityId
            //    INNER JOIN Countries ctr ON ctr.Id = ct.CountryId
            //    INNER JOIN Rooms r ON r.PropertyId = p.Id
            //    INNER JOIN RoomCategories rc on r.RoomCategory = rc.Id
            //    INNER JOIN RoomReservations rr ON rr.RoomId = r.Id
            //    INNER JOIN Reservations rsv ON rsv.Id = rr.ReservationID
            //WHERE rc.Price BETWEEN 70 AND 2000
            //    AND((rsv.CancelDate = NULL
            //            AND rsv.CheckOutDate < GETDATE())
            //        OR day(rsv.CheckInDate) > day(GETDATE() + 1)
            //        OR(rsv.CheckOutDate > GETDATE()
            //            AND rsv.CancelDate <= GETDATE()))
            // AND ctr.Name = 'Algeria'
            //GROUP BY p.Name;

            //var e8 = cinerva.RoomReservations.Include(rr => rr.Reservation)
            //                                 .Include(rr => rr.Room)
            //                                 .Where(rr => rr.Room.Property.City.Country.Name == "Romania")
            //                                 .GroupBy(rr => new { Name = rr.Room.Property.Name })
            //                                 .Select(q => new { PropertyName = q.Key.Name, Count = q.Sum(rr => (1)) }
            //                                 ).ToList();

            //var ex8 = properties.Include(p => p.Rooms).ThenInclude(r => r.RoomCategory).Include(p => p.Rooms).ThenInclude(r => r.Reservations)
            //                    .Where(p => (p.City.Country.Name == "Romania" &&
            //                                p.)
            //                                )

            //SELECT p.Name, p.Rating
            //FROM Properties p
            //    INNER JOIN PropertyFacilities pf ON pf.PropertyId = p.Id
            //    INNER JOIN GeneralFeatures gf ON gf.Id = pf.FeatureId
            //    INNER JOIN Rooms r ON r.PropertyId = p.Id
            //    INNER JOIN RoomReservations rr ON rr.RoomId = r.Id
            //    INNER JOIN Reservations rsv ON rsv.Id = rr.ReservationID
            //WHERE gf.Name = 'Parking'
            //    --Available Rooms filtering
            //    AND((rsv.CancelDate = NULL
            //            AND rsv.CheckOutDate < GETDATE())
            //        OR day(rsv.CheckInDate) > day(GETDATE() + 1)
            //        OR(rsv.CheckOutDate > GETDATE()
            //            AND rsv.CancelDate <= GETDATE()))
            //ORDER BY p.Rating desc;

                                 
            var e9 = cinerva.RoomReservations.Include(rr => rr.Reservation)
                                             .Include(rr => rr.Room)
                                             .ThenInclude(rr => rr.Property).ThenInclude(p => p.PropertyFacilities)
                                             .Include(rr => rr.Room).ThenInclude(rr => rr.Property).ThenInclude(p => p.PropertyFacilities).ThenInclude(pf => pf.GeneralFeature)
                                             .Where(rr => rr.Room.Property.PropertyFacilities.Count(x => x.GeneralFeature.Name == "Parking") > 0 &&
                                                          (rr.Reservation.CheckInDate > new DateTime(2021, 12, 19) ||
                                                          rr.Reservation.CheckInDate < new DateTime(2021, 12, 18)))
                                                          .OrderByDescending(rr => rr.Room.Property.Rating).Take(1).ToList();

            foreach (var rr in e9)
            {
                Console.WriteLine($"{rr.Room.Property.Name}");
            }
        }
    }
}

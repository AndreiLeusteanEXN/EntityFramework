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

            var users = cinerva.Users.Include(u => u.Role);

            var reviews = cinerva.Reviews.Include(u => u.User);

            var admins = cinerva.Users.Include(u => u.Properties);

            //foreach (var review in reviews)
            //{
            //    Console.WriteLine($"Halo {review.User.FirstName} {review.User.LastName}:\n{review.Description}");
            //}

            foreach (var admin in admins)
            {
                foreach (var property in admin.Properties)
                {
                    Console.WriteLine($"{admin.FirstName} {admin.LastName} is admin of {property.Name}");
                }

            }
        }
    }
}

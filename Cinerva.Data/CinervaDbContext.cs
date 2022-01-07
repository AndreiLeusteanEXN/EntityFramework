using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinerva.Data
{
    public class CinervaDbContext:DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Property> Properties { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<PropertyType> PropertyTypes { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<RoomCategory> RoomCategories { get; set; }
        public DbSet<RoomReservation> RoomReservations { get; set; }
        public DbSet<RoomFeature> RoomFeatures { get; set; }
        public DbSet<GeneralFeature> GeneralFeatures { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<PropertyFacility> PropertyFacilities { get; set; }
        public DbSet<PropertyImage> PropertyImages { get; set; }
        public CinervaDbContext() { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=Laptop-50;Initial Catalog=Cinerva;Integrated Security=True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Role>()
                .HasKey(x => x.Id);
            modelBuilder.Entity<User>()
                .HasOne(x => x.Role)
                .WithMany(x => x.Users)
                .HasForeignKey(x => x.RoleId);
            modelBuilder.Entity<City>()
                .HasOne(x => x.Country)
                .WithMany(x => x.Cities)
                .HasForeignKey(x => x.CountryId);

            modelBuilder.Entity<RoomFacility>()
                .HasOne(x => x.RoomFeature)
                .WithMany(x => x.RoomFacilities)
                .HasForeignKey(x => x.FeatureId);
            modelBuilder.Entity<RoomFacility>()
                .HasOne(x => x.Room)
                .WithMany(x => x.RoomFacilities)
                .HasForeignKey(x => x.RoomId);
            modelBuilder.Entity<RoomFacility>()
                .HasKey(x => new { x.RoomId, x.FeatureId });

            modelBuilder.Entity<Room>()
                .HasMany(x => x.Reservations)
                .WithMany(x => x.Rooms)
                .UsingEntity<RoomReservation>
                (
                    x => x
                        .HasOne(x => x.Reservation)
                        .WithMany(x => x.RoomReservations)
                        .HasForeignKey(x => x.ReservationId),
                    x => x
                        .HasOne(x => x.Room)
                        .WithMany(x => x.RoomReservations)
                        .HasForeignKey(x => x.RoomId),
                    x => x.HasKey(x => x.Id)
                );

            modelBuilder.Entity<Room>()
                 .HasOne(x => x.RoomCategory)
                 .WithMany(x => x.Rooms)
                 .Map
                 .HasForeignKey(x => x.RoomCategoryId);
            modelBuilder.Entity<Reservation>()
                .HasOne(x => x.User)
                .WithMany(x => x.Reservations)
                .HasForeignKey(x => x.UserId);


            modelBuilder.Entity<Property>()
                .HasOne(x => x.User)
                .WithMany(x => x.Properties)
                .HasForeignKey(x => x.AdministratorId);

            modelBuilder.Entity<Property>()
                .HasOne(x => x.PropertyType)
                .WithMany(x => x.Properties)
                .HasForeignKey(x => x.PropertyTypeId);

            modelBuilder.Entity<Property>()
                .HasOne(x => x.City)
                .WithMany(x => x.Properties)
                .HasForeignKey(x => x.CityId);

            modelBuilder.Entity<PropertyImage>()
                .HasOne(x => x.Property)
                .WithMany(x => x.PropertyImages)
                .HasForeignKey(x => x.PropertyId);

            modelBuilder.Entity<PropertyFacility>()
                .HasOne(x => x.GeneralFeature)
                .WithMany(x => x.PropertyFacilities)
                .HasForeignKey(x => x.FeatureId);
            modelBuilder.Entity<PropertyFacility>()
                .HasOne(x => x.Property)
                .WithMany(x => x.PropertyFacilities)
                .HasForeignKey(x => x.PropertyId);
            modelBuilder.Entity<PropertyFacility>()
                .HasKey(x => new { x.PropertyId, x.FeatureId });

            modelBuilder.Entity<Review>()
                .HasOne(x => x.User)
                .WithMany(x => x.Reviews)
                .HasForeignKey(x => x.UserId);
            modelBuilder.Entity<Review>()
                .HasOne(x => x.Property)
                .WithMany(x => x.Reviews)
                .HasForeignKey(x => x.PropertyId);
            modelBuilder.Entity<Review>()
                .HasKey(x => new { x.UserId, x.PropertyId });
        }

    }
}

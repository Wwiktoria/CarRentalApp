using CarRentalApp.Models.DbModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace CarRentalApp.Models
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext() : base("CarRentalAppConnectionString") { }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<Car> Cars { get; set; }
        public DbSet<CarModel> Models { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Rental> Rentals { get; set; }
        public DbSet<Worker> Workers { get; set; }
    }
}
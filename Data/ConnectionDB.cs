using Data.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data
{
    public class ConnectionDB : DbContext
    {
        public virtual DbSet<User> Users { get; set; }

        public virtual DbSet<Reservation> Reservations { get; set; }

        public virtual DbSet<Flight> Flights { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=FlightDB;");
            optionsBuilder.UseLazyLoadingProxies();
        }
    }
}

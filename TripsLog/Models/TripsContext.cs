using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace TripsLog.Models
{
    public class TripsContext : DbContext
    {
        public TripsContext(DbContextOptions<TripsContext> options) : base(options)
        { }

        public DbSet<Trip> Trips { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Trip>().HasData(
                new Trip
                {
                    TripId = 1,
                    Destination = "Miami, FL",
                    StartDate = DateTime.Parse("01/07/2018"),
                    EndDate = DateTime.Parse("01/12/2018"),
                    Accommodation = "Best Western",
                    AccommodationPhone = "314-431-6548",
                    AccommodationEmail = "contact@bedtwesternmiami.com",
                    ThingToDo1 = "Visit friends",
                    ThingToDo2 = "Visit the Beach",
                    ThingToDo3 = "Relax"
                },
                new Trip
                {
                    TripId = 2,
                    Destination = "New York, NY",
                    StartDate = DateTime.Parse("07/23/2020"),
                    EndDate = DateTime.Parse("07/20/2020"),
                    ThingToDo1 = "Attend wedding"
                });
        }
    }
}

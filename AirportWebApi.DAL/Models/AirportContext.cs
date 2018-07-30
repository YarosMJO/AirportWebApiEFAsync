using Microsoft.EntityFrameworkCore;

namespace AirportWebApi.DAL.Models
{
    public class AirportContext : DbContext
    {
        public AirportContext(DbContextOptions<AirportContext> options) :
            base(options)
        { }
        public AirportContext()
        {
            Database.EnsureCreated();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Crew>()
            .HasOne(p => p.Pilot);
            modelBuilder.Entity<Crew>()
            .HasMany(p => p.FlightAttendants);

            modelBuilder.Entity<Flight>()
            .HasMany(p => p.Tickets);

            modelBuilder.Entity<Plane>()
            .HasOne(p => p.Type);

            modelBuilder.Entity<Departure>()
            .HasOne(p => p.Plane);

            modelBuilder.Entity<Departure>()
           .HasOne(p => p.Crew);
        }

        public DbSet<Flight> Flights { get; set; }
        public DbSet<Departure> Departures { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<Plane> Planes { get; set; }
        public DbSet<PlaneType> PlaneTypes { get; set; }
        public DbSet<Crew> Crews { get; set; }
        public DbSet<Pilot> Pilots { get; set; }
        public DbSet<FlightAttendant> FlightAttendants { get; set; }

    }
}
using DomainModel.Authentication;
using DomainModel.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FlightManagementWebAPI.DatabaseContext
{
    public class AirportSystemContext : IdentityDbContext<ApplicationUser>
    {
        public AirportSystemContext(DbContextOptions<AirportSystemContext> options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }

        //tablica
        public DbSet<Flight> Flights { get; set; }
        public DbSet<Carrier> Carriers { get; set; }
        public DbSet<Passenger> Passengers { get; set; }
        public DbSet<User> Users { get; set; }
    }
}

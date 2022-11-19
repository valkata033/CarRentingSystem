using CarRentingSystem.Infrastructure.Data.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CarRentingSystem.Infrastructure.Data
{
    public class CarRentingDbContext : IdentityDbContext<ApplicationUser>
    {
        public CarRentingDbContext(DbContextOptions<CarRentingDbContext> options)
            : base(options)
        {
        }

        public DbSet<Car> Cars { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Dealer> Dealers { get; set; }

        public DbSet<City> Cities { get; set; }

        public DbSet<Reservation> Reservations { get; set; }

        public DbSet<CityDealer> CitiesDealers { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<CityDealer>()
                .HasKey(x => new { x.CityId, x.DealerId });

            builder.Entity<ApplicationUser>()
                .Property(x => x.UserName)
                .HasMaxLength(30)
                .IsRequired();

            builder.Entity<ApplicationUser>()
                .Property(x => x.Email)
                .HasMaxLength(30)
                .IsRequired();

            base.OnModelCreating(builder);
        }
    }
}
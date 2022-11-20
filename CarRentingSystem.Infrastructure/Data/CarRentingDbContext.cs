using CarRentingSystem.Infrastructure.Data.Configuration;
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

        public DbSet<ReservationPeriod> ReservationPeriods { get; set; }

        public DbSet<Dealership> Dealerships { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<ApplicationUser>()
                .Property(x => x.UserName)
                .HasMaxLength(30)
                .IsRequired();

            builder.Entity<ApplicationUser>()
                .Property(x => x.Email)
                .HasMaxLength(30)
                .IsRequired();

            builder.ApplyConfiguration(new CategoryConfiguration());
            builder.ApplyConfiguration(new CityConfiguration());
            builder.ApplyConfiguration(new DealerConfiguration());
            builder.ApplyConfiguration(new CarConfiguration());
            builder.ApplyConfiguration(new UserConfiguration());
            builder.ApplyConfiguration(new DealershipConfiguration());
            builder.ApplyConfiguration(new ReservationConfiguration());
            builder.ApplyConfiguration(new ReservationPeriodConfiguration());

            base.OnModelCreating(builder);
        }
    }
}
using CarRentingSystem.Infrastructure.Data.Configuration;
using CarRentingSystem.Infrastructure.Data.Models;
using Microsoft.AspNetCore.Identity;
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

            builder.Entity<IdentityRole>()
                .HasData(
                new IdentityRole()
                {
                    Id = "20be60b0-71ee-4297-ad72-4e4ca05b2fc8",
                    Name = "User",
                    NormalizedName = "USER",
                    ConcurrencyStamp = "e1de8b7d-1975-4210-ae6f-b7b585e4e086"
                },
                new IdentityRole()
                {
                    Id = "9390e3f1-821d-4d96-b3bb-397d373b7b04",
                    Name = "Dealer",
                    NormalizedName = "DEALER",
                    ConcurrencyStamp = "5823a48a-b52a-4af7-8f5a-3cee87997481"
                },
                new IdentityRole()
                {
                    Id = "0eff399e-8200-43c8-b58d-f790d528f98b",
                    Name = "Administrator",
                    NormalizedName = "ADMINISTRATOR",
                    ConcurrencyStamp = "d21d75c0-e85b-4ed3-b69b-fe62a93299c1"
                });

            builder.Entity<IdentityUserRole<string>>()
                .HasData(
                new IdentityUserRole<string>()
                {
                    UserId = "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                    RoleId = "20be60b0-71ee-4297-ad72-4e4ca05b2fc8"
                },
                new IdentityUserRole<string>()
                {
                    UserId = "dea12856-c198-4129-b3f3-b893d8395082",
                    RoleId = "9390e3f1-821d-4d96-b3bb-397d373b7b04"
                },
                new IdentityUserRole<string>()
                {
                    UserId = "4078b0fd-3914-461c-8c6b-06bda682647d",
                    RoleId = "9390e3f1-821d-4d96-b3bb-397d373b7b04"
                },
                new IdentityUserRole<string>()
                {
                    UserId = "bcc313a0-a38a-42a2-a42c-d00f09a89c5f",
                    RoleId = "0eff399e-8200-43c8-b58d-f790d528f98b"
                });

            builder.ApplyConfiguration(new UserConfiguration());
            builder.ApplyConfiguration(new DealerConfiguration());
            builder.ApplyConfiguration(new CarConfiguration());
            builder.ApplyConfiguration(new ReservationConfiguration());
            builder.ApplyConfiguration(new DealershipConfiguration());
            builder.ApplyConfiguration(new ReservationPeriodConfiguration());
            builder.ApplyConfiguration(new CityConfiguration());
            builder.ApplyConfiguration(new CategoryConfiguration());

            base.OnModelCreating(builder);
        }
    }
}
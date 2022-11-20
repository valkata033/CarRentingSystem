using CarRentingSystem.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CarRentingSystem.Infrastructure.Data.Configuration
{
    internal class DealerConfiguration : IEntityTypeConfiguration<Dealer>
    {   
        public void Configure(EntityTypeBuilder<Dealer> builder)
        {
            builder.HasData(CreateDealers());
        }

        private List<Dealer> CreateDealers()
        {
            return new List<Dealer>() 
            {
                new Dealer()
                {
                    Id = 1,
                    Name = "Luxury Cars",
                    PhoneNumber = "+359884588735",
                    UserId = "dea12856-c198-4129-b3f3-b893d8395082"
                },
                new Dealer()
                {
                    Id = 2,
                    Name = "Professional Rentals",
                    PhoneNumber = "+359887329454",
                    UserId = "dea12856-c198-4129-b3f3-b893d8395082"
                },
                new Dealer()
                {
                    Id = 3,
                    Name = "Rental Central",
                    PhoneNumber = "+359885571323",
                    UserId = "dea12856-c198-4129-b3f3-b893d8395082"
                },
                new Dealer()
                {
                    Id = 4,
                    Name = "Deluxe Car Rentalss",
                    PhoneNumber = "+359889324572",
                    UserId = "dea12856-c198-4129-b3f3-b893d8395082"
                }
            };
        }
    }
}

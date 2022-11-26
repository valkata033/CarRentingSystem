using CarRentingSystem.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CarRentingSystem.Infrastructure.Data.Configuration
{
    internal class DealershipConfiguration : IEntityTypeConfiguration<Dealership>
    {
        public void Configure(EntityTypeBuilder<Dealership> builder)
        {
            builder.HasData(CreateDealerships());
        }

        private List<Dealership> CreateDealerships()
        {
            return new List<Dealership>()
            {
                new Dealership()
                {
                    Id = 1,
                    Name = "Sofia Dealership",
                    Adderss = "Sofia Airport",
                    CityId = 1,
                    DealerId = 1,
                },
                new Dealership()
                {
                    Id = 2,
                    Name = "Plovdiv Dealership",
                    Adderss = "Plovdiv Center",
                    CityId = 2,
                    DealerId = 2,
                }
                /*
                new Dealership()
                {
                    Id = 3,
                    Name = "Burgas Dealership",
                    Adderss = "Burgas Center",
                    CityId = 3,
                    DealerId = 3,
                },
                new Dealership()
                {
                    Id = 4,
                    Name = "Vidin Dealership",
                    Adderss = "Vidin Center",
                    CityId = 4,
                    DealerId = 4,
                },
                new Dealership()
                {
                    Id = 5,
                    Name = "Varna Dealership",
                    Adderss = "Varna Center",
                    CityId = 5,
                    DealerId = 3,
                },
                */
            };
        }
    }
}

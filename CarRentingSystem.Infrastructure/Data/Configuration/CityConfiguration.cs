using CarRentingSystem.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CarRentingSystem.Infrastructure.Data.Configuration
{
    internal class CityConfiguration : IEntityTypeConfiguration<City>
    {
        public void Configure(EntityTypeBuilder<City> builder)
        {
            builder.HasData(CreateCities());
        }

        private List<City> CreateCities()
        {
            return new List<City>()
            {
                new City()
                {
                    Id = 1,
                    Name = "Sofia",
                },
                new City()
                {
                    Id = 2,
                    Name = "Plovdiv",
                },
                new City()
                {
                    Id = 3,
                    Name = "Burgas",
                },
                new City()
                {
                    Id = 4,
                    Name = "Vidin",
                },
                new City()
                {
                    Id = 5,
                    Name = "Varna",
                }
            };
        }
    }
}

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
            var cities = new List<City>();

            var city = new City()
            {
                Id = 1,
                Name = "Sofia",
                
            };
            cities.Add(city);


            return cities;
        }
    }
}

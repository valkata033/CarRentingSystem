using CarRentingSystem.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CarRentingSystem.Infrastructure.Data.Configuration
{
    internal class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasData(CreateCategories());
        }

        private List<Category> CreateCategories()
        {
            return new List<Category>(){
                new Category()
                {
                    Id = 1,
                    Name = "SUV"
                },
                new Category()
                {
                    Id = 2,
                    Name = "Hatchback"
                },
                new Category()
                {
                    Id = 3,
                    Name = "Sedan"
                },
                new Category()
                {
                    Id = 4,
                    Name = "Crossover"
                },
                new Category()
                {
                    Id = 5,
                    Name = "Sports Car"
                },
                new Category()
                {
                    Id = 6,
                    Name = "Coupe"
                },
                new Category()
                {
                    Id = 7,
                    Name = "Minivan"
                },
                new Category()
                {
                    Id = 8,
                    Name = "Station Wagon"
                }
            };
        }
    }
}

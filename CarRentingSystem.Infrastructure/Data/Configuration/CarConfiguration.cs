using CarRentingSystem.Infrastructure.Data.Models;
using CarRentingSystem.Infrastructure.Data.Models.Enum;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CarRentingSystem.Infrastructure.Data.Configuration
{
    internal class CarConfiguration : IEntityTypeConfiguration<Car>
    {
        public void Configure(EntityTypeBuilder<Car> builder)
        {
            builder.HasData(CreateCars());
        }

        private List<Car> CreateCars()
        {
            return new List<Car>()
            {
                new Car()
                {
                    Id = 1,
                    Brand = "BMW",
                    Model = "530",
                    MakeYear = 2014,
                    Description = "Very good car for youngth renter or for family.",
                    PricePerDay = 50,
                    FuelType = Fuel.Diesel,
                    Gearbox = Gearbox.Manual,
                    ImageUrl = "https://imgd.aeplcdn.com/0x0/ec/69/55/13232/img/l/BMW-5-Series-Front-view-27016.jpg?q=75",
                    CategoryId = 3,
                    DealerId = 2,
                    RenterId = "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e"
                },
                new Car()
                {
                    Id = 2,
                    Brand = "Mercedes",
                    Model = "C 220",
                    MakeYear = 2012,
                    FuelType = Fuel.Diesel,
                    Gearbox = Gearbox.Automatic,
                    Description = "Very good car for family.",
                    PricePerDay = 35,
                    ImageUrl = "https://o.aolcdn.com/images/dims3/GLOB/legacy_thumbnail/800x450/format/jpg/quality/85/http://www.blogcdn.com/www.autoblog.com/media/2011/06/2012-mercedes-benz-c-class-coupe.jpg",
                    CategoryId = 3,
                    DealerId = 2,
                },
                new Car()
                {
                    Id = 3,
                    Brand = "Mercedes",
                    Model = "S 500",
                    MakeYear = 2020,
                    FuelType = Fuel.Gasoline,
                    Gearbox = Gearbox.Automatic,
                    Description = "Very luxury car for rich people.",
                    PricePerDay = 100,
                    ImageUrl = "https://paultan.org/image/2020/09/2021-W223-Mercedes-Benz-S-Class-White-9-1200x628.jpg",
                    CategoryId = 3,
                    DealerId = 1,
                },
                new Car()
                {
                    Id = 4,
                    Brand = "Mazda",
                    Model = "CX-5",
                    MakeYear = 2019,
                    FuelType = Fuel.Gasoline,
                    Gearbox = Gearbox.Manual,
                    Description = "Very good for family car.",
                    PricePerDay = 80,
                    ImageUrl = "https://hips.hearstapps.com/hmg-prod/amv-prod-cad-assets/wp-content/uploads/2018/01/2018-10Best-Trucks-SUVs-Mazda-CX-5-2p5L-lp.jpg?resize=480:*",
                    CategoryId = 1,
                    DealerId = 1,
                },
                new Car()
                {
                    Id = 5,
                    Brand = "Porsche",
                    Model = "911 Turbo S",
                    MakeYear = 2017,
                    FuelType = Fuel.Gasoline,
                    Gearbox = Gearbox.Automatic,
                    Description = "Very fast car for people who want to make some new advantures.",
                    PricePerDay = 110,
                    ImageUrl = "https://www.auto-data.net/images/f15/file6121570.jpg",
                    CategoryId = 5,
                    DealerId = 1,
                },
                new Car()
                {
                    Id = 6,
                    Brand = "BMW",
                    Model = "M3",
                    MakeYear = 2015,
                    FuelType = Fuel.Diesel,
                    Gearbox = Gearbox.Manual,
                    Description = "Very good car for youngth people and people who want to make some new advantures.",
                    PricePerDay = 75,
                    ImageUrl = "http://hauteliving.com/wp-content/uploads/2014/07/M4_Coupe_127.jpg",
                    CategoryId = 6,
                    DealerId = 2,
                }
            };
        }
    }
}

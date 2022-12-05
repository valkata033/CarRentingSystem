using CarRentingSystem.Core.Contracts;

namespace CarRentingSystem.Core.Models.Car
{
    public class CarHomeModel : ICarModel
    {
        public int Id { get; set; }

        public string Brand { get; set; } = null!;

        public string Model { get; set; } = null!;

        public string ImageUrl { get; set; } = null!;

        public int PricePerDay { get; set; }
    }
}

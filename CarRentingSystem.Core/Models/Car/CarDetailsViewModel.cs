namespace CarRentingSystem.Core.Models.Car
{
    public class CarDetailsViewModel
    {
        public int Id { get; init; }

        public string Brand { get; init; } = null!;

        public string Model { get; init; } = null!;

        public string ImageUrl { get; init; } = null!;

        public string Category { get; init; } = null!;
    }
}

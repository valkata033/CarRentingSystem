using CarRentingSystem.Core.Contracts;
using CarRentingSystem.Infrastructure.Data.Models.Enum;
using System.ComponentModel.DataAnnotations;

namespace CarRentingSystem.Core.Models.Car
{
    public class CarModel : ICarModel
    {
        public int Id { get; init; }

        public string Brand { get; init; } = null!;

        public string Model { get; init; } = null!;

        [Display(Name = "Price Per Day")]
        public int PricePerDay { get; init; }

        public Gearbox Gearbox { get; set; }

        [Display(Name = "Fuel Type")]
        public Fuel FuelType { get; set; }

        [Display(Name = "Image URL")]
        public string ImageUrl { get; init; } = null!;

        [Display(Name = "Is Rented")]
        public bool IsRented { get; set; }
    }
}

using CarRentingSystem.Infrastructure.Data.Models.Enum;
using System.ComponentModel.DataAnnotations;

namespace CarRentingSystem.Core.Models.Car
{
    public class CarModel
    {
        public int Id { get; set; }

        public string Brand { get; set; } = null!;

        public string Model { get; set; } = null!;

        [Display(Name = "Make Year")]
        public int MakeYear { get; set; }

        [Display(Name = "Price Per Day")]
        public int PricePerDay { get; set; }

        public string Description { get; set; } = null!;

        public Gearbox Gearbox { get; set; }

        [Display(Name = "Fuel Type")]
        public Fuel FuelType { get; set; }

        [Display(Name = "Image URL")]
        public string ImageUrl { get; set; } = null!;

        [Display(Name = "Is Rented")]
        public bool IsRented { get; set; }
    }
}

using CarRentingSystem.Infrastructure.Data.GlobalConstants;
using CarRentingSystem.Infrastructure.Data.Models.Enum;
using System.ComponentModel.DataAnnotations;

namespace CarRentingSystem.Core.Models.Car
{
    public class CarFormModel
    {
        [Required]
        [StringLength(DataConstants.Car.CarBrandMaxValue, MinimumLength = DataConstants.Car.CarBrandMinValue)]
        public string Brand { get; set; } = null!;

        [Required]
        [StringLength(DataConstants.Car.CarModelMaxValue, MinimumLength = DataConstants.Car.CarModelMinValue)]
        public string Model { get; set; } = null!;

        [Required]
        [StringLength(DataConstants.Car.CarImageUrlMaxValue, MinimumLength = DataConstants.Car.CarImageUrlMinValue)]
        [Display(Name = "Image URL")]
        public string ImageUrl { get; set; } = null!;

        [Required]
        [StringLength(DataConstants.Car.CarDescriptionMaxValue, MinimumLength = DataConstants.Car.CarDescriptionMinValue)]
        public string Description { get; set; } = null!;

        [Required]
        [Range(DataConstants.Car.CarMakeYearMinValue, DataConstants.Car.CarMakeYearMaxValue, 
            ErrorMessage = "Make year must be positive number between {1} and {2}")]
        [Display(Name = "Make year")]
        public int MakeYear { get; set; }

        [Required]
        [Display(Name = "Fuel type")]
        public Fuel FuelType { get; set; }

        [Required]
        public Gearbox Gearbox { get; set; }

        [Required]
        [Range(DataConstants.Car.CarPriceMinValue, DataConstants.Car.CarPriceMaxValue,
            ErrorMessage = "Price must be positive number between {1} and {2}")]
        [Display(Name = "Price per day")]
        public int PricePerDay { get; set; }

        [Required]
        [Display(Name = "Category")]
        public int CategoryId { get; set; }

        public IEnumerable<CarCategoryServiceModel> Categories { get; set; } 
            = new List<CarCategoryServiceModel>();

    }
}

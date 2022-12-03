using CarRentingSystem.Infrastructure.Data.GlobalConstants;
using CarRentingSystem.Infrastructure.Data.Models.Enum;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarRentingSystem.Infrastructure.Data.Models
{
    public class Car
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(DataConstants.Car.CarBrandMaxValue)]
        public string Brand { get; set; } = null!;

        [Required]
        [StringLength(DataConstants.Car.CarModelMaxValue)]
        public string Model { get; set; } = null!;

        [Required]
        public int MakeYear { get; set; }

        [Required]
        public Gearbox Gearbox { get; set; }

        [Required]
        public Fuel FuelType { get; set; }

        [Required]
        [StringLength(DataConstants.Car.CarDescriptionMaxValue)]
        public string Description { get; set; } = null!;

        [Required]
        public int PricePerDay { get; set; }

        [Required]
        [StringLength(DataConstants.Car.CarImageUrlMaxValue)]
        public string ImageUrl { get; set; } = null!;

        [Required]
        [ForeignKey(nameof(Category))]
        public int CategoryId { get; set; }
        public Category Category { get; set; } = null!;

        [Required]
        [ForeignKey(nameof(Dealer))]
        public int DealerId { get; set; }
        public Dealer Dealer { get; set; } = null!;


        [ForeignKey(nameof(Renter))]
        public string? RenterId { get; set; }
        public ApplicationUser? Renter { get; set; }
    }
}

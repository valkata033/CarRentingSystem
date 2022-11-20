using CarRentingSystem.Infrastructure.Data.GlobalConstants;
using Microsoft.EntityFrameworkCore;
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
        [Column(TypeName = DataConstants.Car.CarPriceSQLDataType)]
        [Precision(DataConstants.Car.CarPriceLength, DataConstants.Car.CarPricePrecision)]
        [Range(typeof(decimal), DataConstants.Car.CarPriceMinValue, DataConstants.Car.CarPriceMaxValue)]
        public decimal PricePerMonth { get; set; }

        [Required]
        public int Year { get; set; }

        [Required]
        [StringLength(DataConstants.Car.CarDescriptionMaxValue)]
        public string Description { get; set; } = null!;

        [Required]
        [StringLength(DataConstants.Car.CarImageUrlMaxValue)]
        public string ImageUrl { get; set; } = null!;

        [Required]
        public bool IsRented { get; set; }

        [Required]
        [ForeignKey(nameof(Category))]
        public int CategoryId { get; set; }
        public Category Category { get; set; } = null!;

        [Required]
        [ForeignKey(nameof(Dealer))]
        public int DealerId { get; set; }
        public Dealer Dealer { get; set; } = null!;

        [Required]
        [ForeignKey(nameof(Reservation))]
        public int ReservationId { get; set; }

        public Reservation Reservation { get; set; } = null!;

    }
}

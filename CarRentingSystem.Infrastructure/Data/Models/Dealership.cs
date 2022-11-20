using CarRentingSystem.Infrastructure.Data.GlobalConstants;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarRentingSystem.Infrastructure.Data.Models
{
    public class Dealership
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(DataConstants.Dealership.DealershipNameMaxValue)]
        public string Name { get; set; } = null!;

        [Required]
        [StringLength(DataConstants.Dealership.DealershipAddressMaxValue)]
        public string Adderss { get; set; } = null!;

        [Required]
        [ForeignKey(nameof(City))]
        public int CityId { get; set; }

        public City City { get; set; } = null!;

        [Required]
        public int DealerId { get; set; }

        public Dealer Dealer { get; set; } = null!;

    }
}

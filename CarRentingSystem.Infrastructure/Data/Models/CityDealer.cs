using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarRentingSystem.Infrastructure.Data.Models
{
    public class CityDealer
    {
        [Required]
        [ForeignKey(nameof(City))]
        public int CityId { get; set; }

        public City City { get; set; } = null!;


        [Required]
        [ForeignKey(nameof(Dealer))]
        public int DealerId { get; set; }

        public Dealer Dealer { get; set; } = null!;

    }
}

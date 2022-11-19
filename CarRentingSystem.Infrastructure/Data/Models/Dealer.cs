using CarRentingSystem.Infrastructure.Data.GlobalConstants;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarRentingSystem.Infrastructure.Data.Models
{
    public class Dealer
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(DataConstants.Dealer.DealerNameMaxValue)]
        public string Name { get; set; } = null!;

        [Required]
        [StringLength(DataConstants.Dealer.DealerPhoneMaxValue)]
        [Phone]
        public string PhoneNumber { get; set; } = null!;

        [Required]
        [ForeignKey(nameof(User))]
        public string UserId { get; set; } = null!;

        public ApplicationUser User { get; set; } = null!;

        public IEnumerable<Car> Cars { get; set; } = new List<Car>();

    }
}

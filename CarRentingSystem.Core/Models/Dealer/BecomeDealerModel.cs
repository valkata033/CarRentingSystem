using System.ComponentModel.DataAnnotations;
using CarRentingSystem.Infrastructure.Data.GlobalConstants;

namespace CarRentingSystem.Core.Models.Dealer
{
    public class BecomeDealerModel
    {
        [Required]
        [StringLength(DataConstants.Dealer.DealerPhoneMaxValue, MinimumLength = DataConstants.Dealer.DealerPhoneMinValue)]
        [Display(Name = "Phone Number")]
        [Phone]
        public string PhoneNumber { get; set; } = null!;

        [Required]
        [StringLength(DataConstants.Dealer.DealerNameMaxValue, MinimumLength = DataConstants.Dealer.DealerNameMinValue)]
        public string Name { get; set; } = null!;
    }
}

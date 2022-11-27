using System.ComponentModel.DataAnnotations;

namespace CarRentingSystem.Core.Models.Dealer
{
    public class DealerServiceModel
    {
        [Required]
        public string Name { get; set; } = null!;

        [EmailAddress]
        public string Email { get; set; } = null!;

        [Phone]
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; } = null!;

    }
}

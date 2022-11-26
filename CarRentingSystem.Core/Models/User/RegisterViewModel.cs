using System.ComponentModel.DataAnnotations;
using CarRentingSystem.Infrastructure.Data.GlobalConstants;

namespace CarRentingSystem.Core.Models.User
{
    public class RegisterViewModel
    {

        [Required]
        [StringLength(DataConstants.User.UserNameMaxValue, MinimumLength = DataConstants.User.UserNameMinValue)]
        public string UserName { get; set; } = null!;

        [Required]
        [StringLength(DataConstants.User.UserFullNameMaxValue, MinimumLength = DataConstants.User.UserFullNameMinValue)]
        public string FullName { get; set; } = null!;

        [Required]
        [EmailAddress]
        [StringLength(DataConstants.User.UserEmailAddressMaxValue, MinimumLength = DataConstants.User.UserEmailAddressMinValue)]
        public string Email { get; set; } = null!;

        [Required]
        [StringLength(DataConstants.User.UserPasswordMaxValue, MinimumLength = DataConstants.User.UserPasswordMinValue)]
        [DataType(DataType.Password)]
        public string Password { get; set; } = null!;

        [Required]
        [Compare(nameof(Password))]
        [StringLength(DataConstants.User.UserPasswordMaxValue, MinimumLength = DataConstants.User.UserPasswordMinValue)]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; } = null!;
    }
}

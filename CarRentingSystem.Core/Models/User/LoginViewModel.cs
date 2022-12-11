using System.ComponentModel.DataAnnotations;
using CarRentingSystem.Infrastructure.Data.GlobalConstants;
using Microsoft.AspNetCore.Authentication;

namespace CarRentingSystem.Core.Models.User
{
    public class LoginViewModel
    {
        [Required]
        [EmailAddress]
        [StringLength(DataConstants.User.UserEmailAddressMaxValue, MinimumLength = DataConstants.User.UserEmailAddressMinValue)]
        public string Email { get; set; } = null!;

        [StringLength(DataConstants.User.UserPasswordMaxValue, MinimumLength = DataConstants.User.UserPasswordMinValue)]
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; } = null!;

        public IList<AuthenticationScheme> ExternalLogins { get; set; }
            = new List<AuthenticationScheme>();
    }
}

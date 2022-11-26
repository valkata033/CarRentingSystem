using System.ComponentModel.DataAnnotations;

namespace CarRentingSystem.Core.Models.User
{
    public class LoginViewModel
    {
        [Required]
        [EmailAddress]
        [StringLength(60, MinimumLength = 10)]
        public string Email { get; set; } = null!;

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; } = null!;
    }
}

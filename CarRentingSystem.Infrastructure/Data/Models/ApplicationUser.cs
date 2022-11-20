using CarRentingSystem.Infrastructure.Data.GlobalConstants;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace CarRentingSystem.Infrastructure.Data.Models
{
    public class ApplicationUser : IdentityUser
    {
        [Required]
        [StringLength(DataConstants.User.UserFullNameMaxValue)]
        public string FullName { get; set; } = null!;
    }
}

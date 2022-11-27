using CarRentingSystem.Core.Models.Dealer;
using System.ComponentModel.DataAnnotations;

namespace CarRentingSystem.Core.Models.Car
{
    public class CarDetailsModel : CarModel
    {

        [Display(Name = "Make Year")]
        public int MakeYear { get; set; }

        public string Description { get; set; } = null!;

        public string Category { get; set; } = null!;

        public DealerServiceModel Dealer { get; set; } = null!;
    }
}

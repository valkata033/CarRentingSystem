using CarRentingSystem.Infrastructure.Data.GlobalConstants;
using CarRentingSystem.Infrastructure.Data.Models;
using System.ComponentModel.DataAnnotations;
using static CarRentingSystem.Infrastructure.Data.GlobalConstants.DataConstants;
using City = CarRentingSystem.Infrastructure.Data.Models.City;

namespace CarRentingSystem.Core.Models.Dealer
{
    public class AddDealershipModel
    {
        [Required]
        [StringLength(DataConstants.Dealership.DealershipNameMaxValue, MinimumLength = DataConstants.Dealership.DealershipNameMinValue)]
        public string Name { get; set; } = null!;

        [Required]
        [StringLength(DataConstants.Dealership.DealershipAddressMaxValue, MinimumLength = DataConstants.Dealership.DealershipAddressMinValue)]
        public string Address { get; set; } = null!;

        [Required]
        [Display(Name = "City")]
        public int CityId { get; set; }

        public IEnumerable<AllCitiesServiceModel> Cities { get; set; }
            = new List<AllCitiesServiceModel>();
    }
}

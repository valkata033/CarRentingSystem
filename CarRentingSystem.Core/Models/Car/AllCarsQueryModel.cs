using System.ComponentModel;

namespace CarRentingSystem.Core.Models.Car
{
    public class AllCarsQueryModel
    {
        public const int CarsPerPage = 3;

        public string Category { get; set; } = null!;

        [DisplayName("Search Term")]
        public string SearchTerm { get; init; } = null!;

        public CarSorting Sorting { get; init; }

        public int CurrentPage { get; init; } = 1;

        public int TotalCarsCount { get; set; }

        public IEnumerable<string> Categories { get; set; } = null!;

        public IEnumerable<CarModel> Cars { get; set; } = new List<CarModel>();

    }
}

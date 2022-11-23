namespace CarRentingSystem.Core.Models.Car
{
    public class CarsQueryServiceModel
    {
        public int TotalCarsCount { get; set; }

        public IEnumerable<CarModel> Cars { get; set; } = new List<CarModel>();
    }
}

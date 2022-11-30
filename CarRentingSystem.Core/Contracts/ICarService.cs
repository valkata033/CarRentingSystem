using CarRentingSystem.Core.Models.Car;

namespace CarRentingSystem.Core.Contracts
{
    public interface ICarService
    {
        Task<IEnumerable<CarModel>> GetAllCarsAsync();

        Task<CarsQueryServiceModel> All(string category = null, string searchItem = null,
            CarSorting sorting = CarSorting.Newest, int currentPage = 1,
            int housePerPage = 1);

        Task<IEnumerable<string>> AllCategoriesNames();

        Task<bool> CategoryExist(int categoryId);

        Task<IEnumerable<CarCategoryServiceModel>> AllCategories();

        Task<IEnumerable<CarModel>> AllCarsByUserId(string userId);

        Task<IEnumerable<CarModel>> AllCarsByDealerId(int dealerId);

        Task<bool> Exists(int carId);

        Task<int> CreateCar(CarFormModel model, int dealerId);

        Task<CarDetailsModel> GetCarsDetailsById(int carId);
    }
}

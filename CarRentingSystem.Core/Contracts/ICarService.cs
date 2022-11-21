using CarRentingSystem.Core.Models.Car;

namespace CarRentingSystem.Core.Contracts
{
    public interface ICarService
    {
        Task<IEnumerable<CarHomeModel>> GetAllCarsAsync();


    }
}

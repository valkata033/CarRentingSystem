using CarRentingSystem.Core.Models.Dealer;

namespace CarRentingSystem.Core.Contracts
{
    public interface IDealerService
    {
        Task Create(string userId, string phoneNumber, string name, string roleName);

        Task<bool> ExistsById(string userId);

        Task<int> GetDealerId(string userId);

        Task<bool> HasDealerWithPhoneNumber(string phoneNumber);

        Task AddDealership(string userId, AddDealershipModel model);

        Task<IEnumerable<CityServiceModel>> GetAllCitiesAsync();

        Task<bool> CityExistById(int cityId);
    }
}

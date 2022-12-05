namespace CarRentingSystem.Core.Contracts
{
    public interface IDealerService
    {
        Task Create(string userId, string phoneNumber, string name, string roleName);

        Task<bool> ExistsById(string userId);

        Task<int> GetDealerId(string userId);

        Task<bool> HasDealerWithPhoneNumber(string phoneNumber);
    }
}

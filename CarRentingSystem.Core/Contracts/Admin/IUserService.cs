using CarRentingSystem.Core.Models.Admin;

namespace CarRentingSystem.Core.Contracts.Admin
{
    public interface IUserService
    {
        Task<string> GetUserFullNameAsync(string userId);

        Task<IEnumerable<UserServiceModel>> GetAllAsync();

        Task DeleteUser(string userId);
    }
}

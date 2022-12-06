using CarRentingSystem.Core.Models.Admin;

namespace CarRentingSystem.Core.Contracts.Admin
{
    public interface IRentService
    {
        Task<IEnumerable<AllRentsModel>> GetAllRentsAsync();

    }
}

using CarRentingSystem.Core.Models.Admin;

namespace CarRentingSystem.Core.Contracts.Admin
{
    public interface IDealershipService
    {
        Task<IEnumerable<AllDealershipsModel>> GetAllDealershipsAsync();
    }
}

using CarRentingSystem.Core.Contracts.Admin;
using CarRentingSystem.Core.Models.Admin;
using CarRentingSystem.Infrastructure.Data.Common;
using CarRentingSystem.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace CarRentingSystem.Core.Services.Admin
{
    public class DealershipService : IDealershipService
    {
        private readonly IRepository repo;

        public DealershipService(IRepository _repo)
        {
            repo = _repo;
        }

        public async Task<IEnumerable<AllDealershipsModel>> GetAllDealershipsAsync()
        {
            return await repo.All<Dealership>()
                .OrderBy(x => x.Id)
                .Select(x => new AllDealershipsModel()
                {
                    Id = x.Id,
                    Name = x.Name,
                    Address = x.Adderss,
                    City = x.City.Name
                })
                .ToListAsync(); 
        }
    }
}

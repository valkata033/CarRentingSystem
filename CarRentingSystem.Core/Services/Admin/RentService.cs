using CarRentingSystem.Core.Contracts.Admin;
using CarRentingSystem.Core.Models.Admin;
using CarRentingSystem.Infrastructure.Data.Common;
using CarRentingSystem.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace CarRentingSystem.Core.Services.Admin
{
    public class RentService : IRentService
    {
        private readonly IRepository repo;

        public RentService(IRepository _repo)
        {
            repo = _repo;
        }

        public async Task<IEnumerable<AllRentsModel>> GetAllRentsAsync()
        {
            return await repo.All<Reservation>()
                .Select(x => new AllRentsModel()
                {
                    Id = x.Id,
                    StartDate = x.StartDate,
                    EndDate = x.EndDate,
                    Price = x.Price,
                    IsActive = x.IsActive
                })
                .ToListAsync();
        }
    }
}

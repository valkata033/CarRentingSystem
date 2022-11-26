using CarRentingSystem.Core.Contracts;
using CarRentingSystem.Infrastructure.Data.Models;
using HouseRentingSystem.Infrastructure.Data.Common;
using Microsoft.EntityFrameworkCore;

namespace CarRentingSystem.Core.Services
{
    public class DealerService : IDealerService
    {
        private readonly IRepository repo;

        public DealerService(IRepository _repo)
        {
            repo = _repo;
        }

        public async Task Create(string userId, string phoneNumber, string name)
        {
            var dealer = new Dealer()
            {
                UserId = userId,
                PhoneNumber = phoneNumber,
                Name = name
            };

            await repo.AddAsync(dealer);
            await repo.SaveChangesAsync();
        }

        public async Task<bool> ExistsById(string userId)
        {
            return await repo.AllReadonly<Dealer>()
                .AnyAsync(x => x.UserId == userId);
        }

        public async Task<int> GetDealerId(string userId)
        {
            return (await repo.AllReadonly<Dealer>()
                .FirstOrDefaultAsync(x => x.UserId == userId))?.Id ?? 0;
        }

        public async Task<bool> HasDealerWithPhoneNumber(string phoneNumber)
        {
            return await repo.AllReadonly<Dealer>()
                .AnyAsync(x => x.PhoneNumber == phoneNumber);
        }
    }
}

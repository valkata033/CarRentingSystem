using CarRentingSystem.Core.Contracts;
using CarRentingSystem.Infrastructure.Data.Common;
using CarRentingSystem.Infrastructure.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace CarRentingSystem.Core.Services
{
    public class DealerService : IDealerService
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IRepository repo;

        public DealerService(
            IRepository _repo,
            UserManager<ApplicationUser> _userManager)
        {
            repo = _repo;
            userManager = _userManager;
        }

        public async Task Create(string userId, string phoneNumber, string name, string roleName)
        {
            var user = await userManager.FindByNameAsync(userId);

            var dealer = new Dealer()
            {
                UserId = userId,
                PhoneNumber = phoneNumber,
                Name = name
            };

            await repo.AddAsync(dealer);
            await userManager.AddToRoleAsync(user, roleName);
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

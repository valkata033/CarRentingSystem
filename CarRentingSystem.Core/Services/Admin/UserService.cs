using CarRentingSystem.Core.Contracts.Admin;
using CarRentingSystem.Core.Models.Admin;
using CarRentingSystem.Infrastructure.Data.Common;
using CarRentingSystem.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace CarRentingSystem.Core.Services.Admin
{
    public class UserService : IUserService
    {
        private readonly IRepository repo;

        public UserService(IRepository _repo)
        {
            repo = _repo;
        }

        public async Task<IEnumerable<UserServiceModel>> GetAllAsync()
        {
            List<UserServiceModel> result;

            result = await repo.AllReadonly<Dealer>()
                .Select(x => new UserServiceModel()
                {
                    UserId = x.UserId,
                    FullName = x.User.FullName,
                    Email = x.User.Email,
                    PhoneNumber = x.PhoneNumber
                })
                .ToListAsync();

            string[] dealerIds = result.Select(x => x.UserId).ToArray();

            result.AddRange(await repo.AllReadonly<ApplicationUser>()
                .Where(u => dealerIds.Contains(u.Id) == false)
                .Select(x => new UserServiceModel()
                {
                    UserId = x.Id,
                    Email = x.Email,
                    FullName = x.FullName 
                })
                .ToListAsync());

            return result;
        }

        public async Task<string> GetUserFullNameAsync(string userId)
        {
            var user = await repo.GetByIdAsync<ApplicationUser>(userId);

            return user.FullName;
        }
    }
}

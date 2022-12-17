using CarRentingSystem.Core.Contracts.Admin;
using CarRentingSystem.Core.Models.Admin;
using CarRentingSystem.Infrastructure.Data.GlobalConstants;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using static CarRentingSystem.Areas.Administrator.Constants.AdminConstants;

namespace CarRentingSystem.Areas.Administrator.Controllers
{
    public class UserController : BaseController
    {
        private readonly IUserService userService;
        private readonly IMemoryCache cache;

        public UserController(
            IUserService _userService,
            IMemoryCache _cache)
        {
            userService = _userService;
            cache = _cache;
        }

        public async Task<IActionResult> All()
        {
            var users = cache.Get<IEnumerable<UserServiceModel>>(UsersCacheKey);

            if (users == null)
            {
                users = await userService.GetAllAsync();

                var cacheOptions = new MemoryCacheEntryOptions()
                    .SetAbsoluteExpiration(TimeSpan.FromMinutes(5));

                cache.Set(UsersCacheKey, users, cacheOptions);
            }

            return View(users);
        }

        public async Task<IActionResult> Delete(string UserId)
        {
            try
            {
                await userService.DeleteUser(UserId);
            }
            catch (Exception)
            {
                TempData[MessageConstants.ErrorMessage] = "Something went wrong! Could not delete user!";
                return RedirectToAction(nameof(All));
            }

            TempData[MessageConstants.SuccessMessage] = "You deleted a user successfully!";
            cache.Remove(UsersCacheKey);

            return RedirectToAction(nameof(All));
        }
    }
}

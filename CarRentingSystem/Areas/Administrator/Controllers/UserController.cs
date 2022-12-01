using CarRentingSystem.Core.Contracts.Admin;
using Microsoft.AspNetCore.Mvc;

namespace CarRentingSystem.Areas.Administrator.Controllers
{
    public class UserController : BaseController
    {
        private readonly IUserService userService;

        public UserController(IUserService _userService)
        {
            userService = _userService;
        }

        public async Task<IActionResult> All()
        {
            var model = await userService.GetAllAsync();

            return View(model);
        }
    }
}

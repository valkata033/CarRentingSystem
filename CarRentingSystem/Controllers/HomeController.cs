using CarRentingSystem.Areas.Administrator.Controllers;
using CarRentingSystem.Core.Contracts;
using CarRentingSystem.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using static CarRentingSystem.Areas.Administrator.Constants.AdminConstants;

namespace CarRentingSystem.Controllers
{
    public class HomeController : Controller
    {
        private readonly ICarService cars;

        public HomeController(ICarService _cars)
        {
            cars = _cars;
        }

        public async Task<IActionResult> Index()
        {
            if (User.IsInRole(AdminRoleName))
            {
                return RedirectToAction(nameof(AdminController.Index), "Admin", new { area = AreaName });
            }

            var model = await cars.GetAllCarsAsync();

            return View(model);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
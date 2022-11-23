using CarRentingSystem.Core.Contracts;
using CarRentingSystem.Core.Models.Car;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CarRentingSystem.Controllers
{
    [Authorize]
    public class CarController : Controller
    {
        private readonly ICarService cars;

        public CarController(ICarService _cars)
        {
            cars = _cars;
        }

        [AllowAnonymous]
        public async Task<IActionResult> All([FromQuery] AllCarsQueryModel model)
        {
            var queryResult = await cars.All(
                model.Category,
                model.SearchTerm,
                model.Sorting,
                model.CurrentPage,
                AllCarsQueryModel.CarsPerPage);

            model.TotalCarsCount = queryResult.TotalCarsCount;
            model.Cars = queryResult.Cars;

            var carsCategories = await cars.AllCategoriesNames();
            model.Categories = carsCategories;

            return View(model);
        }
    }
}

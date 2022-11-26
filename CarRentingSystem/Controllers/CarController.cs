using CarRentingSystem.Core.Contracts;
using CarRentingSystem.Core.Models.Car;
using CarRentingSystem.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CarRentingSystem.Controllers
{
    [Authorize]
    public class CarController : Controller
    {
        private readonly ICarService cars;
        private readonly IDealerService dealers;

        public CarController(ICarService _cars, IDealerService _dealers)
        {
            cars = _cars;
            dealers = _dealers;
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

        public async Task<IActionResult> Mine()
        {
            IEnumerable<CarModel> myCars = null;

            string userId = User.Id();

            if (await dealers.ExistsById(userId))
            {
                var currDealerId = await dealers.GetDealerId(userId);

                myCars = await cars.AllCarsByDealerId(currDealerId);
            }
            else
            {
                myCars = await cars.AllCarsByUserId(userId);
            }

            return View(myCars);
        }
    }
}

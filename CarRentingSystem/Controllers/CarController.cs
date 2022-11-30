using CarRentingSystem.Core.Contracts;
using CarRentingSystem.Core.Models.Car;
using CarRentingSystem.Extensions;
using CarRentingSystem.Infrastructure.Data.GlobalConstants;
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

        public async Task<IActionResult> Details(CarDetailsModel model)
        {
            if ((await cars.Exists(model.Id)) == false)
            {
                TempData[MessageConstants.ErrorMessage] = "Car with this id do not exist!";

                return RedirectToAction(nameof(HomeController.Index), "Home");
            }

            var carModel = await cars.GetCarsDetailsById(model.Id);

            return View(carModel);
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            return View(new CarFormModel()
            {
                Categories = await cars.AllCategories()
            });
        }

        [HttpPost]
        public async Task<IActionResult> Add(CarFormModel carModel)
        {
            if (User.IsInRole("Dealer") == false)
            {
                TempData[MessageConstants.ErrorMessage] = "You must be dealer to add cars!";
                return RedirectToAction(nameof(DealerController.Become), "Dealer");
            }

            if ((await dealers.ExistsById(User.Id())) == false)
            {
                TempData[MessageConstants.ErrorMessage] = "You must be dealer to add cars!";
                return RedirectToAction(nameof(DealerController.Become), "Dealer");
            }

            if ((await cars.CategoryExist(carModel.CategoryId)) == false)
            {
                ModelState.AddModelError(nameof(carModel.CategoryId), "Category does not exist!");
            }

            if (!ModelState.IsValid)
            {
                carModel.Categories = await cars.AllCategories();

                TempData[MessageConstants.ErrorMessage] = "Invalid data!";

                return View(carModel);
            }

            int dealerId = await dealers.GetDealerId(User.Id());

            int id = await cars.CreateCar(carModel, dealerId);

            return RedirectToAction(nameof(Details), new { id });
        }
    }
}

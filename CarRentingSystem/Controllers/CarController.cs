using CarRentingSystem.Core.Contracts;
using CarRentingSystem.Core.Models.Car;
using CarRentingSystem.Extensions;
using CarRentingSystem.Infrastructure.Data.GlobalConstants;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static CarRentingSystem.Areas.Administrator.Constants.AdminConstants;

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

        public async Task<IActionResult> Details(CarDetailsModel modell)
        {
            if ((await cars.Exists(modell.Id)) == false)
            {
                TempData[MessageConstants.ErrorMessage] = "Car with this id do not exist!";

                return RedirectToAction(nameof(HomeController.Index), "Home");
            }

            var carModel = await cars.GetCarsDetailsById(modell.Id);

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
            if (User.IsInRole(DealerRoleName) == false)
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

            TempData[MessageConstants.SuccessMessage] = "You have successfully added a car!";

            return RedirectToAction(nameof(Details), new { id });
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            if (!await cars.Exists(id))
            {
                TempData[MessageConstants.ErrorMessage] = "This car does not exist!";
                return RedirectToAction(nameof(All));
            }

            if (!await cars.HasDealerWithId(id, User.Id()))
            {
                TempData[MessageConstants.ErrorMessage] = "You can not edit this car!";
                return RedirectToAction(nameof(All));
            }

            var car = await cars.GetCarsDetailsById(id);

            int carCategoryId = await cars.GetCarCategoryId(car.Id);

            var houseModel = new CarFormModel()
            {
                Brand = car.Brand,
                MakeYear = car.MakeYear,
                Model = car.Model,
                Description = car.Description,
                PricePerDay = car.PricePerDay,
                ImageUrl = car.ImageUrl,
                FuelType = car.FuelType,
                Gearbox = car.Gearbox,
                CategoryId = carCategoryId,
                Categories = await cars.AllCategories()
            };

            return View(houseModel);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, CarFormModel carModel)
        {
            if (!await cars.Exists(id))
            {
                TempData[MessageConstants.ErrorMessage] = "This car does not exist!";
                return RedirectToAction(nameof(All));
            }

            if (!await cars.HasDealerWithId(id, User.Id()))
            {
                TempData[MessageConstants.ErrorMessage] = "You can not edit this car!";
                return RedirectToAction(nameof(All));
            }

            if (!await cars.CategoryExist(carModel.CategoryId))
            {
                ModelState.AddModelError(nameof(carModel.CategoryId),
                    "This category does not exist!");
            }

            if (!ModelState.IsValid)
            {
                carModel.Categories = await cars.AllCategories();
                return View(carModel);
            }

            await cars.Edit(id, carModel);

            return RedirectToAction(nameof(Details), new { id });
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            if (!await cars.Exists(id))
            {
                TempData[MessageConstants.ErrorMessage] = "This car does not exist!";
                return RedirectToAction(nameof(All));
            }

            if (!await cars.HasDealerWithId(id, User.Id()))
            {
                TempData[MessageConstants.ErrorMessage] = "You can not delete this car!";
                return RedirectToAction(nameof(All));
            }

            var car = await cars.GetCarsDetailsById(id);

            var model = new CarDetailsViewModel()
            {
                Brand = car.Brand,
                Model = car.Model,
                ImageUrl = car.ImageUrl,
                Category = car.Category
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id, CarDetailsViewModel carModel)
        {
            if (!await cars.Exists(id))
            {
                TempData[MessageConstants.ErrorMessage] = "This car does not exist!";
                return RedirectToAction(nameof(All));
            }

            if (!await cars.HasDealerWithId(id, User.Id()))
            {
                TempData[MessageConstants.ErrorMessage] = "You can not delete this car!";
                return RedirectToAction(nameof(All));
            }

            if (await cars.IsRented(id))
            {
                TempData[MessageConstants.ErrorMessage] = "You can not delete rented cars!";
                return RedirectToAction(nameof(All));
            }

            await cars.Delete(id);

            TempData[MessageConstants.SuccessMessage] = "You remove a car successfully!";
            return RedirectToAction(nameof(All));
        }

        [HttpPost]
        public async Task<IActionResult> Rent(int id)
        {
            if (!await cars.Exists(id))
            {
                TempData[MessageConstants.ErrorMessage] = "This car does not exist!";
                return RedirectToAction(nameof(All));
            }

            if (!User.IsInRole(AdminRoleName) && await dealers.ExistsById(User.Id()))
            {
                TempData[MessageConstants.ErrorMessage] = "Dealers can not rent cars!";
                return RedirectToAction(nameof(All));
            }

            if (await cars.IsRented(id))
            {
                TempData[MessageConstants.ErrorMessage] = "This car is already rented!";
                return RedirectToAction(nameof(All));
            }

            await cars.Rent(id, User.Id());
            TempData[MessageConstants.SuccessMessage] = "You rent a car successfully!";

            return RedirectToAction(nameof(Mine));
        }
        
        [HttpPost]
        public async Task<IActionResult> Leave(int id)
        {
            if (!await cars.Exists(id) || !await cars.IsRented(id))
            {
                TempData[MessageConstants.ErrorMessage] = "This car does not exist!";
                return RedirectToAction(nameof(All));
            }

            if (!await cars.IsRentedByUserById(id, User.Id()))
            {
                TempData[MessageConstants.ErrorMessage] = "Dealers can not leave cars!";
                return RedirectToAction(nameof(All));
            }

            await cars.Leave(id);
            TempData[MessageConstants.SuccessMessage] = "You leave a car successfully!";

            return RedirectToAction(nameof(Mine));
        }
    }
}

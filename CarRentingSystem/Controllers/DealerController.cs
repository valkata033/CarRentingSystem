using CarRentingSystem.Core.Contracts;
using CarRentingSystem.Core.Models.Dealer;
using CarRentingSystem.Extensions;
using CarRentingSystem.Infrastructure.Data.GlobalConstants;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static CarRentingSystem.Areas.Administrator.Constants.AdminConstants;
using static CarRentingSystem.Infrastructure.Data.GlobalConstants.DataConstants;

namespace CarRentingSystem.Controllers
{
    [Authorize]
    public class DealerController : Controller
    {
        private readonly IDealerService dealers;

        public DealerController(IDealerService _dealers)
        {
            dealers = _dealers;
        }

        [HttpGet]
        public async Task<IActionResult> Become()
        {
            if (await dealers.ExistsById(User.Id()))
            {
                TempData[MessageConstants.ErrorMessage] = "You are already dealer!";

                return RedirectToAction(nameof(HomeController.Index), "Home");
            }

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Become(BecomeDealerModel model)
        {
            var userId = User.Id();

            if (await dealers.ExistsById(userId))
            {
                TempData[MessageConstants.ErrorMessage] = "You are already dealer!";

                return RedirectToAction(nameof(HomeController.Index), "Home");
            }

            if (await dealers.HasDealerWithPhoneNumber(model.PhoneNumber))
            {
                ModelState.AddModelError(nameof(model.PhoneNumber),
                    "Phone number already exist. Enter another one.");
            }

            if (!ModelState.IsValid)
            {
                TempData[MessageConstants.ErrorMessage] = "Invalid data!";
                return View(model);
            }

            try
            {
                await dealers.Create(userId, model.PhoneNumber, model.Name, DealerRoleName);
            }
            catch (Exception)
            {
                TempData[MessageConstants.ErrorMessage] = "Something get wrong! Check your data!";
                return View(model);
            }

            TempData[MessageConstants.SuccessMessage] = "You become dealer successfully!";

            return RedirectToAction(nameof(CarController.All), "Car");
        }

        [HttpGet]
        public async Task<IActionResult> AddDealership()
        {
            //if (await dealers.ExistsById(User.Id()))
            //{
            //    TempData[MessageConstants.ErrorMessage] = "You must be dealer to add dealerships!";

            //    return RedirectToAction(nameof(HomeController.Index), "Home");
            //}

            return View(new AddDealershipModel()
            {
                Cities = await dealers.GetAllCitiesAsync()
            });
        }

        [HttpPost]
        public async Task<IActionResult> AddDealership(AddDealershipModel model)
        {
            var userId = User.Id();

            if ((await dealers.ExistsById(userId)) == false)
            {
                TempData[MessageConstants.ErrorMessage] = "You must be dealer to add dealerships!";

                return RedirectToAction(nameof(HomeController.Index), "Home");
            }

            if ((await dealers.CityExistById(model.CityId)) == false)
            {
                TempData[MessageConstants.ErrorMessage] = "This city does not exist!";

                return RedirectToAction(nameof(HomeController.Index), "Home");
            }

            if (!ModelState.IsValid)
            {
                model.Cities = await dealers.GetAllCitiesAsync();

                TempData[MessageConstants.ErrorMessage] = "Invalid data!";
                return View(model);
            }

            try
            {
                await dealers.AddDealership(userId, model);
            }
            catch (Exception)
            {
                TempData[MessageConstants.ErrorMessage] = "Something get wrong! Check your data!";
                return View(model);
            }

            TempData[MessageConstants.SuccessMessage] = "You added a dealership successfully!";

            return RedirectToAction(nameof(CarController.All), "Car");
        }
    }
}

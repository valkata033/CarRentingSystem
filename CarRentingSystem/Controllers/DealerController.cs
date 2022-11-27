using CarRentingSystem.Core.Contracts;
using CarRentingSystem.Core.Models.Dealer;
using CarRentingSystem.Extensions;
using CarRentingSystem.Infrastructure.Data.GlobalConstants;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

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
                return View(model);
            }

            await dealers.Create(userId, model.PhoneNumber, model.Name);

            TempData[MessageConstants.SuccessMessage] = "You become dealer successfully!";

            return RedirectToAction(nameof(CarController.All), "Car");
        }
    }
}

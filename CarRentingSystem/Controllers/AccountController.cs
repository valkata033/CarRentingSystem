using Microsoft.AspNetCore.Mvc;

namespace CarRentingSystem.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

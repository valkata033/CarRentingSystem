using Microsoft.AspNetCore.Mvc;

namespace CarRentingSystem.Controllers
{
    public class CarController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

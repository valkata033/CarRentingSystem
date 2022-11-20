using Microsoft.AspNetCore.Mvc;

namespace CarRentingSystem.Controllers
{
    public class DealerController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

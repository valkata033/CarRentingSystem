using Microsoft.AspNetCore.Mvc;

namespace CarRentingSystem.Areas.Administrator.Controllers
{
    public class AdminController : BaseController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

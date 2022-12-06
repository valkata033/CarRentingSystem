using CarRentingSystem.Core.Contracts.Admin;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;

namespace CarRentingSystem.Areas.Administrator.Controllers
{
    public class RentController : BaseController
    {
        private readonly IRentService rentService;
        private readonly IMemoryCache cache;

        public RentController(
            IRentService _rentService,
            IMemoryCache _cache)
        {
            rentService = _rentService;
            cache = _cache;
        }

        public async Task<IActionResult> All()
        {
            var rents = await rentService.GetAllRentsAsync();
            
            return View(rents);
        }
    }
}


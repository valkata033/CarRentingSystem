using CarRentingSystem.Core.Contracts.Admin;
using CarRentingSystem.Core.Models.Admin;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using static CarRentingSystem.Areas.Administrator.Constants.AdminConstants;

namespace CarRentingSystem.Areas.Administrator.Controllers
{
    public class DealershipController : BaseController
    {
        private readonly IDealershipService service;
        private readonly IMemoryCache cache;

        public DealershipController(
            IDealershipService _service,
            IMemoryCache _cache)
        {
            service = _service;
            cache = _cache;
        }

        public async Task<IActionResult> All()
        {
            var dealerships = cache.Get<IEnumerable<AllDealershipsModel>>(DealershipsCacheKey);

            if (dealerships == null)
            {
                dealerships = await service.GetAllDealershipsAsync();

                var cacheOptions = new MemoryCacheEntryOptions()
                    .SetAbsoluteExpiration(TimeSpan.FromMinutes(5));

                cache.Set(DealershipsCacheKey, dealerships, cacheOptions);
            }

            return View(dealerships);
        }
    }
}

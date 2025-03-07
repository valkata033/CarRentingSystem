﻿using CarRentingSystem.Core.Contracts.Admin;
using CarRentingSystem.Core.Models.Admin;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using static CarRentingSystem.Areas.Administrator.Constants.AdminConstants;

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
            var rents = cache.Get<IEnumerable<AllRentsModel>>(RentsCacheKey);

            if (rents == null)
            {
                rents = await rentService.GetAllRentsAsync();

                var cacheOptions = new MemoryCacheEntryOptions()
                    .SetAbsoluteExpiration(TimeSpan.FromMinutes(5));

                cache.Set(RentsCacheKey, rents, cacheOptions);
            }

            return View(rents);
        }
    }
}


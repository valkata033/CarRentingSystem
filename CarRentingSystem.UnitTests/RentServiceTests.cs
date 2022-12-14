using CarRentingSystem.Core.Contracts.Admin;
using CarRentingSystem.Infrastructure.Data.Common;
using CarRentingSystem.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarRentingSystem.Core.Services.Admin;
using CarRentingSystem.Infrastructure.Data.Models;

namespace CarRentingSystem.UnitTests
{
    [TestFixture]
    public class RentServiceTests
    {
        private IRepository repo;
        private IRentService rentService;
        private CarRentingDbContext context;

        [SetUp]
        public void Setup()
        {
            var contextOptions = new DbContextOptionsBuilder<CarRentingDbContext>()
                .UseInMemoryDatabase("CarDb")
                .Options;

            context = new CarRentingDbContext(contextOptions);

            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();
        }

        [Test]
        public async Task ShouldReturnAllRents()
        {
            var repo = new Repository(context);
            rentService = new RentService(repo);

            var user = new ApplicationUser() { Id = "user", UserName = "", Email = "", FullName = "" };
            await repo.AddAsync(user);

            var car = new Car() { Id = 1, Brand = "", Model = "", Description = "", ImageUrl = "", PricePerDay = 0, Gearbox = 0, FuelType = 0, CategoryId = 0, DealerId = 1, IsActive = true, RenterId = "" };
            await repo.AddAsync(car);

            await repo.AddAsync(new ReservationPeriod() { Id = 1, Days = 3 });
            var period = await repo.GetByIdAsync<ReservationPeriod>(1);

            await repo.AddAsync(new Reservation()
            {
                Id = 1,
                StartDate = DateTime.Now,
                EndDate = DateTime.Now,
                IsActive = true,
                CarId = car.Id,
                Price = 0,
                ReservationPeriodId = period.Id
            });

            await repo.SaveChangesAsync();

            var rents = await rentService.GetAllRentsAsync();

            Assert.That(rents.Count(), Is.EqualTo(1));

        }

        [TearDown]
        public void TearDown()
        {
            context.Dispose();
        }
    }
}

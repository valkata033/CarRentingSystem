using CarRentingSystem.Core.Contracts;
using CarRentingSystem.Core.Contracts.Admin;
using CarRentingSystem.Core.Services.Admin;
using CarRentingSystem.Infrastructure.Data;
using CarRentingSystem.Infrastructure.Data.Common;
using CarRentingSystem.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace CarRentingSystem.UnitTests
{
    [TestFixture]
    public class DealershipServiceTests
    {
        private IRepository repo;
        private IDealershipService dealershipService;
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
        public async Task ShouldReturnAllDealerships()
        {
            var repo = new Repository(context);
            dealershipService = new DealershipService(repo);

            var dealer = new Dealer() { Id = 1, Name = "", PhoneNumber = "", UserId = "" };
            await repo.AddAsync(dealer);

            var city = new City() { Id = 1, Name = "Vidin"};

            await repo.AddRangeAsync(new List<Dealership>() {
                new Dealership() { Id = 1, Name = "", Adderss = "", City = city, Dealer = dealer},
                new Dealership() { Id = 2, Name = "", Adderss = "", City = city, Dealer = dealer},
                new Dealership() { Id = 3, Name = "", Adderss = "", City = city, Dealer = dealer}
            });

            await repo.SaveChangesAsync();

            var dealerships = await dealershipService.GetAllDealershipsAsync();

            Assert.That(dealerships.Count(), Is.EqualTo(3));
        }

        [TearDown]
        public void TearDown()
        {
            context.Dispose();
        }
    }
}

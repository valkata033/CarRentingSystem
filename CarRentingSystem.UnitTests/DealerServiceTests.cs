using CarRentingSystem.Core.Contracts;
using CarRentingSystem.Core.Models.Dealer;
using CarRentingSystem.Core.Services;
using CarRentingSystem.Infrastructure.Data;
using CarRentingSystem.Infrastructure.Data.Common;
using CarRentingSystem.Infrastructure.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Moq;

namespace CarRentingSystem.UnitTests
{
    public class DealerServiceTests
    {
        private IRepository repo;
        private IDealerService dealerService;
        private CarRentingDbContext context;
        private UserManager<ApplicationUser> userManager;

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
        public async Task ShouldReturnIfCityExistByGivenId()
        {
            Mock<UserManager<ApplicationUser>> userManager = GetMockUserManager();

            var repo = new Repository(context);
            dealerService = new DealerService(repo, userManager.Object);

            await repo.AddAsync(new City() { Id = 1, Name = "Vidin"});

            await repo.SaveChangesAsync();

            Assert.That(await dealerService.CityExistById(1), Is.True);
        }

        [Test]
        public async Task ShouldReturnAllCities()
        {
            Mock<UserManager<ApplicationUser>> userManager = GetMockUserManager();

            var repo = new Repository(context);
            dealerService = new DealerService(repo, userManager.Object);

            await repo.AddRangeAsync(new List<City>() {
                new City() { Id = 1, Name = "Vidin" },
                new City() { Id = 2, Name = "Vidin" },
                new City() { Id = 3, Name = "Vidin" }
            });

            await repo.SaveChangesAsync();

            var cities = await dealerService.GetAllCitiesAsync();

            Assert.That(cities.Count(), Is.EqualTo(3));
        }

        [Test]
        public async Task ShouldReturnDealerIdByGivenId()
        {
            Mock<UserManager<ApplicationUser>> userManager = GetMockUserManager();

            var repo = new Repository(context);
            dealerService = new DealerService(repo, userManager.Object);

            await repo.AddAsync(new Dealer() { Id = 1, Name = "Gosho", PhoneNumber = "0883487819", UserId = "test" });

            await repo.SaveChangesAsync();

            var dealerId = await dealerService.GetDealerId("test");

            Assert.That(dealerId, Is.EqualTo(1));
        }

        [Test]
        public async Task ShouldReturnDealerPhoneByGivenPhoneNumber()
        {
            Mock<UserManager<ApplicationUser>> userManager = GetMockUserManager();

            var repo = new Repository(context);
            dealerService = new DealerService(repo, userManager.Object);

            await repo.AddAsync(new Dealer() { Id = 1, Name = "Gosho", PhoneNumber = "0883487819", UserId = "test" });

            await repo.SaveChangesAsync();

            var hasDealerPhoneNumber = await dealerService.HasDealerWithPhoneNumber("0883487819");

            Assert.That(hasDealerPhoneNumber, Is.True);
        }

        [Test]
        public async Task ShouldReturnIfDealerExistByGivenId()
        {
            Mock<UserManager<ApplicationUser>> userManager = GetMockUserManager();

            var repo = new Repository(context);
            dealerService = new DealerService(repo, userManager.Object);

            await repo.AddAsync(new Dealer() { Id = 1, Name = "Gosho", PhoneNumber = "0883487819", UserId = "test" });

            await repo.SaveChangesAsync();

            var userExists = await dealerService.ExistsById("test");

            Assert.IsTrue(userExists);
        }

        [Test]
        public async Task ShouldAddNewDealership()
        {
            Mock<UserManager<ApplicationUser>> userManager = GetMockUserManager();

            var repo = new Repository(context);
            dealerService = new DealerService(repo, userManager.Object);

            await repo.AddAsync(new Dealer() { Id = 1, Name = "Gosho", PhoneNumber = "0883487819", UserId = "test" });

            await repo.SaveChangesAsync();

            var model = new AddDealershipModel() { Name = "Vidin", Address = "", CityId = 1};

            await dealerService.AddDealership("test", model);

            var dealership = await repo.GetByIdAsync<Dealership>(1);

            Assert.That(dealership.Id, Is.EqualTo(1));
            Assert.That(dealership.Name, Is.EqualTo("Vidin"));
        }

        [Test]
        public async Task ShouldAddNewDealer()
        {
            Mock<UserManager<ApplicationUser>> userManager = GetMockUserManager();

            var repo = new Repository(context);
            dealerService = new DealerService(repo, userManager.Object);

            var user = new ApplicationUser() { Id = "user", UserName = "", Email = "", FullName = "" };
            await repo.AddAsync(user);

            await dealerService.Create("user", "0884348736", "Gosho", "Dealer");

            var dealer = await repo.GetByIdAsync<Dealer>(1);

            Assert.That(dealer.Id, Is.EqualTo(1));
            Assert.That(dealer.Name, Is.EqualTo("Gosho"));
        }

        [TearDown]
        public void TearDown()
        {
            context.Dispose();
        }

        private Mock<UserManager<ApplicationUser>> GetMockUserManager()
        {
            var userStoreMock = new Mock<IUserStore<ApplicationUser>>();
            return new Mock<UserManager<ApplicationUser>>(
            userStoreMock.Object, null, null, null, null, null, null, null, null);
        }
    }
}

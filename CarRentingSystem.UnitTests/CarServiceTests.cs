using CarRentingSystem.Core.Contracts;
using CarRentingSystem.Core.Models.Car;
using CarRentingSystem.Core.Models.Dealer;
using CarRentingSystem.Core.Services;
using CarRentingSystem.Infrastructure.Data;
using CarRentingSystem.Infrastructure.Data.Common;
using CarRentingSystem.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;
using Moq;
using NUnit.Framework;

namespace CarRentingSystem.UnitTests
{
    [TestFixture]
    public class CarServiceTests
    {
        private IRepository repo;
        private ICarService carService;
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
        public async Task ShouldReturnAllCarsCount()
        {
            var repo = new Repository(context);
            carService = new CarService(repo);

            await repo.AddRangeAsync(new List<Car>()
            {
                new Car() { Id = 1, Brand = "", Model = "", Description = "", ImageUrl = "", PricePerDay = 0, Gearbox = 0, FuelType = 0, CategoryId = 0, DealerId = 0},
                new Car() { Id = 2, Brand = "", Model = "", Description = "", ImageUrl = "", PricePerDay = 0, Gearbox = 0, FuelType = 0, CategoryId = 0, DealerId = 0},
            });

            await repo.SaveChangesAsync();
            var cars = await carService.All();

            Assert.That(2, Is.EqualTo(cars.TotalCarsCount));
        }

        [Test]
        public async Task ShouldReturnAllActiveCarsCount()
        {
            var repo = new Repository(context);
            carService = new CarService(repo);

            await repo.AddRangeAsync(new List<Car>()
            {
                new Car() { Id = 1, Brand = "", Model = "", Description = "", ImageUrl = "", PricePerDay = 0, Gearbox = 0, FuelType = 0, CategoryId = 0, DealerId = 0, IsActive = true},
                new Car() { Id = 2, Brand = "", Model = "", Description = "", ImageUrl = "", PricePerDay = 0, Gearbox = 0, FuelType = 0, CategoryId = 0, DealerId = 0, IsActive = false},
            });

            await repo.SaveChangesAsync();
            var cars = await carService.All();

            Assert.That(1, Is.EqualTo(cars.TotalCarsCount));
        }

        [Test]
        public async Task ShouldReturnAllCarsByGivenDealer()
        {
            var repo = new Repository(context);
            carService = new CarService(repo);
            
            var dealer = new Dealer() { Id = 1, Name = "", PhoneNumber = "", UserId = ""};
            await repo.AddAsync(dealer);

            await repo.AddRangeAsync(new List<Car>()
            {
                new Car() { Id = 1, Brand = "", Model = "", Description = "", ImageUrl = "", PricePerDay = 0, Gearbox = 0, FuelType = 0, CategoryId = 0, DealerId = 1, IsActive = true},
                new Car() { Id = 2, Brand = "", Model = "", Description = "", ImageUrl = "", PricePerDay = 0, Gearbox = 0, FuelType = 0, CategoryId = 0, DealerId = 1, IsActive = true},
            });

            await repo.SaveChangesAsync();

            var cars = await carService.AllCarsByDealerId(1);

            Assert.That(dealer.Cars.Count(), Is.EqualTo(cars.Count()));
            Assert.That(dealer.Cars.Any(x => x.Id == 1), Is.True);
        }

        [Test]
        public async Task ShouldReturnAllCarsByGivenUser()
        {
            var repo = new Repository(context);
            carService = new CarService(repo);

            var user = new ApplicationUser() { Id = "aa", UserName = "", Email = "", FullName = ""};
            await repo.AddAsync(user);

            await repo.AddRangeAsync(new List<Car>()
            {
                new Car() { Id = 1, Brand = "", Model = "", Description = "", ImageUrl = "", PricePerDay = 0, Gearbox = 0, FuelType = 0, CategoryId = 0, DealerId = 1, IsActive = true, RenterId = "aa"},
                new Car() { Id = 2, Brand = "", Model = "", Description = "", ImageUrl = "", PricePerDay = 0, Gearbox = 0, FuelType = 0, CategoryId = 0, DealerId = 1, IsActive = true, RenterId = "aa"},
            });

            await repo.SaveChangesAsync();

            var cars = await carService.AllCarsByUserId("aa");

            Assert.That(cars.Any(x => x.Id == 2));
            Assert.That(cars.Count(), Is.EqualTo(2));
        }

        [Test]
        public async Task ShouldReturnTrueIfItIsDealerWithGivenId()
        {
            var repo = new Repository(context);
            carService = new CarService(repo);

            var user = new ApplicationUser() { Id = "user", UserName = "", Email = "", FullName = "" };
            await repo.AddAsync(user);

            var dealer = new Dealer() { Id = 1, Name = "", PhoneNumber = "", UserId = "user" };
            await repo.AddAsync(dealer);

            await repo.AddAsync(new Car() { Id = 1, Brand = "", Model = "", Description = "", ImageUrl = "", PricePerDay = 0, Gearbox = 0, FuelType = 0, CategoryId = 0, DealerId = 1, IsActive = true });

            await repo.SaveChangesAsync();

            await carService.HasDealerWithId(1, "user");

            Assert.That(dealer.UserId, Is.EqualTo(user.Id));
        }

        [Test]
        public async Task ShouldReturnFalseIfItIsNotDealerWithGivenId()
        {
            var repo = new Repository(context);
            carService = new CarService(repo);

            var user = new ApplicationUser() { Id = "user", UserName = "", Email = "", FullName = "" };
            await repo.AddAsync(user);

            var dealer = new Dealer() { Id = 1, Name = "", PhoneNumber = "", UserId = "" };
            await repo.AddAsync(dealer);

            await repo.AddAsync(new Car() { Id = 1, Brand = "", Model = "", Description = "", ImageUrl = "", PricePerDay = 0, Gearbox = 0, FuelType = 0, CategoryId = 0, DealerId = 1, IsActive = true });

            await repo.SaveChangesAsync();

            await carService.HasDealerWithId(1, "user");

            Assert.That(dealer.UserId, Is.Not.EqualTo(user.Id));
        }

        [Test]
        public async Task ShouldReturnFalseIfDealerWithGivenIdIsNull()
        {
            var repo = new Repository(context);
            carService = new CarService(repo);

            var user = new ApplicationUser() { Id = "user", UserName = "", Email = "", FullName = "" };
            await repo.AddAsync(user);

            var dealer = new Dealer() { Id = 1, Name = "", PhoneNumber = "", UserId = "" };
            await repo.AddAsync(dealer);

            dealer = await repo.GetByIdAsync<Dealer>(3);

            await repo.AddAsync(new Car() { Id = 1, Brand = "", Model = "", Description = "", ImageUrl = "", PricePerDay = 0, Gearbox = 0, FuelType = 0, CategoryId = 0, DealerId = 1, IsActive = true });

            await repo.SaveChangesAsync();

            await carService.HasDealerWithId(1, "user");

            Assert.That(dealer, Is.Null);
        }

        [Test]
        public async Task ShouldReturnAllCategories()
        {
            var repo = new Repository(context);
            carService = new CarService(repo);

            await repo.AddRangeAsync(new List<Category>(){
                new Category() { Id = 1, Name = "SUV" },
                new Category() { Id = 2, Name = "Sport" },
                new Category() { Id = 3, Name = "Van" },
                new Category() { Id = 4, Name = "Coupe" },
            });

            await repo.SaveChangesAsync();

            var categories = await carService.AllCategories();

            Assert.That(categories.Count() == 4);
            Assert.That(categories.Any(x => x.Name == "Van"), Is.True);
            Assert.That(categories.Any(x => x.Name == null), Is.False);
        }

        [Test]
        public async Task ShouldReturnAllCategoriesNames()
        {
            var repo = new Repository(context);
            carService = new CarService(repo);

            await repo.AddRangeAsync(new List<Category>(){
                new Category() { Id = 1, Name = "SUV" },
                new Category() { Id = 2, Name = "Sport" },
                new Category() { Id = 3, Name = "Van" },
                new Category() { Id = 4, Name = "Coupe" },
            });

            await repo.SaveChangesAsync();

            var categories = await carService.AllCategoriesNames();

            Assert.That(categories.Count() == 4);
            Assert.That(categories.Any(x => x == null), Is.False);
        }

        [Test]
        public async Task ShouldReturnCarCategoryId()
        {
            var repo = new Repository(context);
            carService = new CarService(repo);

            await repo.AddAsync(new Car() { Id = 1, Brand = "", Model = "", Description = "", ImageUrl = "", PricePerDay = 0, Gearbox = 0, FuelType = 0, CategoryId = 1, DealerId = 1, IsActive = true });

            await repo.SaveChangesAsync();

            var carCategory = await carService.GetCarCategoryId(1);

            Assert.That(carCategory, Is.EqualTo(1));
        }

        [Test]
        public async Task ShouldReturnIfCarExist()
        {
            var repo = new Repository(context);
            carService = new CarService(repo);

            await repo.AddAsync(new Car() { Id = 1, Brand = "", Model = "", Description = "", ImageUrl = "", PricePerDay = 0, Gearbox = 0, FuelType = 0, CategoryId = 1, DealerId = 1, IsActive = true });

            await repo.SaveChangesAsync();

            Assert.That(await carService.Exists(1), Is.True);
        }

        [Test]
        public async Task ShouldCreateANewCar()
        {
            var repo = new Repository(context);
            carService = new CarService(repo);

            var carModel = new CarFormModel() { Brand = "BMW", Model = "X5", Description = "", ImageUrl = "", MakeYear = 2011, PricePerDay = 70, Gearbox = 0, FuelType = 0, CategoryId = 1 };

            await carService.CreateCar(carModel, 1);

            var car = await repo.GetByIdAsync<Car>(1);

            Assert.That(car, Is.Not.Null);
            Assert.That(car.MakeYear, Is.EqualTo(2011));
        }

        [Test]
        public async Task ShouldDeleteACar()
        {
            var repo = new Repository(context);
            carService = new CarService(repo);

            await repo.AddRangeAsync(new List<Car>()
            {
                new Car() { Id = 1, Brand = "", Model = "", Description = "", ImageUrl = "", PricePerDay = 0, Gearbox = 0, FuelType = 0, CategoryId = 0, DealerId = 1, IsActive = true},
                new Car() { Id = 2, Brand = "", Model = "", Description = "", ImageUrl = "", PricePerDay = 0, Gearbox = 0, FuelType = 0, CategoryId = 0, DealerId = 1, IsActive = true},
            });

            await repo.SaveChangesAsync();
            await carService.Delete(1);

            var cars = await repo.AllReadonly<Car>().ToListAsync();
            var deletedCar = await repo.GetByIdAsync<Car>(1);

            Assert.That(cars.Count(), Is.EqualTo(2));
            Assert.That(deletedCar.IsActive, Is.False);
        }

        [Test]
        public async Task ShouldEditACar()
        {
            var repo = new Repository(context);
            carService = new CarService(repo);

            await repo.AddAsync(new Car() { Id = 1, Brand = "", Model = "", Description = "", ImageUrl = "", PricePerDay = 0, Gearbox = 0, FuelType = 0, CategoryId = 0, DealerId = 1, IsActive = true});

            await repo.SaveChangesAsync();
            await carService.Edit(1, new CarFormModel()
            {
                CategoryId = 1,
                Brand = "BMW",
                Model = "",
                Description = "",
                MakeYear = 0,
                FuelType = 0,
                Gearbox = 0,
                ImageUrl = "",
                PricePerDay = 20
            });

            var car = await repo.GetByIdAsync<Car>(1);

            Assert.That(car.Brand, Is.EqualTo("BMW"));
            Assert.That(car.PricePerDay, Is.EqualTo(20));
        }

        [Test]
        public async Task ShouldReturnIfCarIsRented()
        {
            var repo = new Repository(context);
            carService = new CarService(repo);

            await repo.AddAsync(new Car() { Id = 1, Brand = "", Model = "", Description = "", ImageUrl = "", PricePerDay = 0, Gearbox = 0, FuelType = 0, CategoryId = 0, DealerId = 1, IsActive = true, RenterId = "aa"});

            await repo.SaveChangesAsync();
              
            await carService.IsRented(1);
            var car = await repo.GetByIdAsync<Car>(1);

            Assert.That(car.RenterId, Is.Not.Null);
        }

        [Test]
        public async Task ShouldReturnTrueIfCarIsRentedByGivenUser()
        {
            var repo = new Repository(context);
            carService = new CarService(repo);

            var user = new ApplicationUser() { Id = "user", UserName = "", Email = "", FullName = "" };
            await repo.AddAsync(user);

            await repo.AddAsync(new Car() { Id = 1, Brand = "", Model = "", Description = "", ImageUrl = "", PricePerDay = 0, Gearbox = 0, FuelType = 0, CategoryId = 0, DealerId = 1, IsActive = true, RenterId = "user" });

            await repo.SaveChangesAsync();

            await carService.IsRentedByUserById(1, "user");
            var car = await repo.GetByIdAsync<Car>(1);

            Assert.That(car.RenterId, Is.EqualTo(user.Id));
        }

        [Test]
        public async Task ShouldReturnFalseIfCarIsNull()
        {
            var repo = new Repository(context);
            carService = new CarService(repo);

            var user = new ApplicationUser() { Id = "user", UserName = "", Email = "", FullName = "" };
            await repo.AddAsync(user);

            await repo.AddAsync(new Car() { Id = 1, Brand = "", Model = "", Description = "", ImageUrl = "", PricePerDay = 0, Gearbox = 0, FuelType = 0, CategoryId = 0, DealerId = 1, IsActive = true, RenterId = "user" });

            await repo.SaveChangesAsync();

            await carService.IsRentedByUserById(0, "user");
            var car = await repo.GetByIdAsync<Car>(0);

            Assert.That(car, Is.Null);
        }

        [Test]
        public async Task ShouldReturnFalseIfCarIsRentedByOtherUser()
        {
            var repo = new Repository(context);
            carService = new CarService(repo);

            var user = new ApplicationUser() { Id = "user", UserName = "", Email = "", FullName = "" };
            await repo.AddAsync(user);

            await repo.AddAsync(new Car() { Id = 1, Brand = "", Model = "", Description = "", ImageUrl = "", PricePerDay = 0, Gearbox = 0, FuelType = 0, CategoryId = 0, DealerId = 1, IsActive = true, RenterId = "otherUser" });

            await repo.SaveChangesAsync();

            await carService.IsRentedByUserById(1, "user");
            var car = await repo.GetByIdAsync<Car>(1);

            Assert.That(car.RenterId, Is.Not.EqualTo(user.Id));
        }

        [Test]
        public async Task ShouldRentACar()
        {
            var repo = new Repository(context);
            carService = new CarService(repo);

            var user = new ApplicationUser() { Id = "user", UserName = "", Email = "", FullName = "" };
            await repo.AddAsync(user);

            var car = new Car() { Id = 1, Brand = "", Model = "", Description = "", ImageUrl = "", PricePerDay = 0, Gearbox = 0, FuelType = 0, CategoryId = 0, DealerId = 1, IsActive = true, RenterId = "" };
            await repo.AddAsync(car);

            await repo.AddAsync(new ReservationPeriod() { Id = 1, Days = 3});
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

            await carService.Rent(car.Id, "user");
            var newCar = await repo.GetByIdAsync<Car>(car.Id);

            Assert.That(newCar.RenterId, Is.EqualTo(user.Id));
        }

        [Test]
        public async Task ShouldLeaveACar()
        {
            var repo = new Repository(context);
            carService = new CarService(repo);

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

            var reservation = await repo.GetByIdAsync<Reservation>(1);

            await repo.SaveChangesAsync();

            await carService.Leave(car.Id);
            var newCar = await repo.GetByIdAsync<Car>(car.Id);

            Assert.That(newCar.RenterId, Is.Null);
            Assert.That(reservation.IsActive, Is.False);
        }


        [TearDown]
        public void TearDown()
        {
            context.Dispose();
        }
    }
}

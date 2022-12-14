using CarRentingSystem.Core.Contracts.Admin;
using CarRentingSystem.Core.Services.Admin;
using CarRentingSystem.Infrastructure.Data;
using CarRentingSystem.Infrastructure.Data.Common;
using CarRentingSystem.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace CarRentingSystem.UnitTests
{
    public class UserServiceTests
    {
        private IRepository repo;
        private IUserService userService;
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
        public async Task ShouldReturnAllUsers()
        {
            var repo = new Repository(context);
            userService = new UserService(repo);

            await repo.AddRangeAsync(new List<ApplicationUser>() 
            {
                new ApplicationUser() { Id = "user1", UserName = "", Email = "", FullName = "Gosho Peshev" },
                new ApplicationUser() { Id = "user2", UserName = "", Email = "", FullName = "Ivo Kotsev" },
                new ApplicationUser() { Id = "user3", UserName = "", Email = "", FullName = "Georgi Benov" }
            });

            await repo.SaveChangesAsync();

            var users = await userService.GetAllAsync();

            Assert.That(users.Count(), Is.EqualTo(3));
        }

        [Test]
        public async Task ShouldReturnUserFullname()
        {
            var repo = new Repository(context);
            userService = new UserService(repo);

            var user = new ApplicationUser() { Id = "user", UserName = "", Email = "", FullName = "Gosho Peshev" };
            await repo.AddAsync(user);

            await repo.SaveChangesAsync();

            var userFullname = await userService.GetUserFullNameAsync("user");

            Assert.That(userFullname, Is.EqualTo(user.FullName));
        }

        [TearDown]
        public void TearDown()
        {
            context.Dispose();
        }
    }
}

using CarRentingSystem.Core.Contracts;
using CarRentingSystem.Core.Models.Car;
using CarRentingSystem.Core.Models.Dealer;
using CarRentingSystem.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;
using CarRentingSystem.Infrastructure.Data.Common;

namespace CarRentingSystem.Core.Services
{
    public class CarService : ICarService
    {
        private readonly IRepository repo;

        public CarService(IRepository _repo)
        {
            repo = _repo;
        }

        public async Task<CarsQueryServiceModel> All(string category = null, 
            string searchItem = null, CarSorting sorting = CarSorting.Newest, int currentPage = 1, 
            int CarsPerPage = 1)
        {
            var carsQuery = repo.All<Car>().AsQueryable();

            if (!string.IsNullOrWhiteSpace(category))
            {
                carsQuery = repo.All<Car>().Where(x => x.Category.Name == category);
            }

            if (!string.IsNullOrWhiteSpace(searchItem))
            {
                carsQuery = carsQuery.Where(x =>
                    x.Brand.ToLower().Contains(searchItem.ToLower()) ||
                    x.Model.ToLower().Contains(searchItem.ToLower()) ||
                    x.Description.ToLower().Contains(searchItem.ToLower()));
            }

            carsQuery = sorting switch
            {
                CarSorting.Price => carsQuery.OrderBy(x => x.PricePerDay),
                CarSorting.Newest => carsQuery.OrderByDescending(x => x.Id),
                CarSorting.NotRentedFirst => carsQuery.OrderBy(x => x.RenterId != null)
                    .ThenByDescending(x => x.Id)
            };

            var cars = await carsQuery
                .Skip((currentPage - 1) * CarsPerPage)
                .Take(CarsPerPage)
                .Select(x => new CarModel
                {
                    Id = x.Id,
                    Brand = x.Brand,
                    Model = x.Model,
                    ImageUrl = x.ImageUrl,
                    IsRented = x.RenterId != null,
                    PricePerDay = x.PricePerDay
                })
                .ToListAsync();

            var totalCars = carsQuery.Count();

            return new CarsQueryServiceModel
            {
                Cars = cars,
                TotalCarsCount = totalCars
            };

        }

        public async Task<IEnumerable<CarModel>> AllCarsByDealerId(int dealerId)
        {
            return await repo
               .All<Car>()
               .Where(x => x.DealerId == dealerId)
               .Select(x => new CarModel()
               {
                   Id = x.Id,
                   Brand = x.Brand,
                   Model = x.Model,
                   PricePerDay = x.PricePerDay,
                   Gearbox = x.Gearbox,
                   FuelType = x.FuelType,
                   ImageUrl = x.ImageUrl,
                   IsRented = x.RenterId != null
               })
               .ToListAsync();
        }

        public async Task<IEnumerable<CarModel>> AllCarsByUserId(string userId)
        {
            return await repo
                .All<Car>()
                .Where(x => x.RenterId == userId)
                .Select(x => new CarModel()
                {
                    Id = x.Id,
                    Brand = x.Brand,
                    Model = x.Model,
                    PricePerDay = x.PricePerDay,
                    Gearbox = x.Gearbox,
                    FuelType = x.FuelType,
                    ImageUrl = x.ImageUrl,
                    IsRented = x.RenterId != null
                })
                .ToListAsync();
        }

        public async Task<IEnumerable<string>> AllCategoriesNames()
        {
            return await repo.AllReadonly<Category>()
                .Select(x => x.Name)
                .Distinct()
                .ToListAsync();
        }

        public async Task<bool> Exists(int carId)
        {
            return await repo.AllReadonly<Car>().AnyAsync(x => x.Id == carId);
        }

        public async Task<IEnumerable<CarModel>> GetAllCarsAsync()
        {
            return await repo.AllReadonly<Car>()
                .Select(x => new CarModel()
                {
                    Id = x.Id,
                    Brand = x.Brand,
                    Model = x.Model,
                    ImageUrl = x.ImageUrl
                })
                .ToListAsync();
        }

        public async Task<CarDetailsModel> GetCarsDetailsById(int carId)
        {
            var car =  await repo.AllReadonly<Car>()
                .Where(x => x.Id == carId)
                .Select(x => new CarDetailsModel()
                {
                    Id = x.Id,
                    Brand = x.Brand,
                    Model = x.Model,
                    MakeYear = x.MakeYear,
                    PricePerDay = x.PricePerDay,
                    Description = x.Description,
                    ImageUrl = x.ImageUrl,
                    FuelType = x.FuelType,
                    Gearbox = x.Gearbox,
                    Category = x.Category.Name,
                    Dealer = new DealerServiceModel()
                    {
                        Name = x.Dealer.Name,
                        PhoneNumber = x.Dealer.PhoneNumber,
                        Email = x.Dealer.User.Email
                    }
                })
                .FirstOrDefaultAsync();

            if (car == null)
            {
                throw new ArgumentNullException("Invalid car id");
            }

            return car;
        }
    }
}

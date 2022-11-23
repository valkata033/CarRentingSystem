using CarRentingSystem.Core.Contracts;
using CarRentingSystem.Core.Models.Car;
using CarRentingSystem.Infrastructure.Data.Models;
using HouseRentingSystem.Infrastructure.Data.Common;
using Microsoft.EntityFrameworkCore;

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

        public async Task<IEnumerable<string>> AllCategoriesNames()
        {
            return await repo.AllReadonly<Category>()
                .Select(x => x.Name)
                .Distinct()
                .ToListAsync();
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
    }
}

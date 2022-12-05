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
            var carsQuery = repo.All<Car>()
                .Where(c => c.IsActive == true)
                .AsQueryable();

            if (!string.IsNullOrWhiteSpace(category))
            {
                carsQuery = repo.All<Car>()
                    .Where(x => x.Category.Name == category);
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
               .Where(x => x.IsActive == true)
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
                .Where(x => x.IsActive == true)
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

        public async Task<IEnumerable<CarCategoryServiceModel>> AllCategories()
        {
            return await repo.AllReadonly<Category>()
                .OrderBy(x => x.Id)
                .Select(x => new CarCategoryServiceModel()
                {
                    Id = x.Id,
                    Name = x.Name
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

        public async Task<bool> CategoryExist(int categoryId)
        {
            return await repo.AllReadonly<Category>()
                .AnyAsync(x => x.Id == categoryId);
        }

        public async Task<int> CreateCar(CarFormModel model, int dealerId)
        {
            var car = new Car()
            {
                Brand = model.Brand,
                Model = model.Model,
                MakeYear = model.MakeYear,
                Description = model.Description,
                ImageUrl = model.ImageUrl,
                Gearbox = model.Gearbox,
                FuelType = model.FuelType,
                PricePerDay = model.PricePerDay,
                CategoryId = model.CategoryId,
                DealerId = dealerId
            };

            await repo.AddAsync(car);
            await repo.SaveChangesAsync();

            return car.Id;
        }

        public async Task Delete(int carId)
        {
            var car = await repo.GetByIdAsync<Car>(carId);
            car.IsActive = false;

            await repo.SaveChangesAsync();
        }

        public async Task Edit(int carId, CarFormModel model)
        {
            var car = await repo.GetByIdAsync<Car>(carId);

            car.Brand = model.Brand;
            car.Model = model.Model;
            car.MakeYear = model.MakeYear;
            car.Description = model.Description;
            car.ImageUrl = model.ImageUrl;
            car.Gearbox = model.Gearbox;
            car.FuelType = model.FuelType;
            car.PricePerDay = model.PricePerDay;
            car.CategoryId = model.CategoryId;
            
            await repo.SaveChangesAsync();
        }

        public async Task<bool> Exists(int carId)
        {
            return await repo.AllReadonly<Car>()
                .Where(x => x.IsActive == true)
                .AnyAsync(x => x.Id == carId);
        }

        public async Task<IEnumerable<CarModel>> GetAllCarsAsync()
        {
            return await repo.AllReadonly<Car>()
                .Where(x => x.IsActive == true)
                .Select(x => new CarModel()
                {
                    Id = x.Id,
                    Brand = x.Brand,
                    Model = x.Model,
                    ImageUrl = x.ImageUrl,
                    PricePerDay = x.PricePerDay,
                })
                .ToListAsync();
        }

        public async Task<int> GetCarCategoryId(int carId)
        {
            var car = await repo.GetByIdAsync<Car>(carId);
            return car.CategoryId;
        }

        public async Task<CarDetailsModel> GetCarsDetailsById(int carId)
        {
            var car =  await repo.AllReadonly<Car>()
                .Where(x => x.IsActive == true)
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
                    Gearbox = x.Gearbox,
                    FuelType = x.FuelType,
                    IsRented = x.RenterId != null,
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

        public async Task<bool> HasDealerWithId(int carId, string currUserId)
        {
            var car = await repo.GetByIdAsync<Car>(carId);
            var dealer = await repo.AllReadonly<Dealer>()
                .FirstOrDefaultAsync(x => x.Id == car.DealerId);

            if (dealer == null)
            {
                return false;
            }

            if (dealer.UserId != currUserId)
            {
                return false;
            }

            return true;
        }

        public async Task<bool> IsRented(int id)
        {
            var car = await repo.GetByIdAsync<Car>(id);

            return car.RenterId != null;
        }

        public async Task<bool> IsRentedByUserById(int carId, string userId)
        {
            var car = await repo.GetByIdAsync<Car>(carId);

            if (car == null)
            {
                return false;
            }

            if (car.RenterId != userId)
            {
                return false;
            }

            return true;
        }

        public async Task Leave(int carId)
        {
            var car = await repo.GetByIdAsync<Car>(carId);

            var reservation = await repo.All<Reservation>()
                .Where(x => x.IsActive)
                .FirstOrDefaultAsync(x => x.CarId == carId);

            if (car != null && reservation != null)
            {
                car.RenterId = null;
                reservation.IsActive = false;
            }

            await repo.SaveChangesAsync();
        }

        public async Task Rent(int carId, string userId)
        {
            var car = await repo.GetByIdAsync<Car>(carId);

            var period = await repo.GetByIdAsync<ReservationPeriod>(1);
               
            var reservation = new Reservation()
            {
                StartDate = DateTime.Now,
                EndDate = DateTime.Now.AddDays(period.Days),
                Price = car.PricePerDay * period.Days,
                IsActive = true,
                CarId = carId,
                ReservationPeriodId = period.Id
            };

            await repo.AddAsync(reservation);

            if (car != null)
            {
                car.RenterId = userId;
            }

            await repo.SaveChangesAsync();
        }
    }
}

using CarRentingSystem.Core.Contracts;
using System.Text;

namespace CarRentingSystem.Core.Extensions
{
    public static class ModelExtensions
    {
        public static string GetInformation(this ICarModel car)
        {
            var sb = new StringBuilder();

            sb.Append(car.Brand.Replace(" ", "-"));
            sb.Append("-");
            sb.Append(car.PricePerDay);
            sb.Append("-");
            sb.Append(car.Model.Replace(" ", "-"));

            return sb.ToString();
        }
    }
}

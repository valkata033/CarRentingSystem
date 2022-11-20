namespace CarRentingSystem.Infrastructure.Data.GlobalConstants
{
    public static class DataConstants
    {
        public static class User
        {
            public const int UserEGNMinValue = 10;
            public const int UserEGNMaxValue = 10;
            public const int UserFullNameMinValue = 4;
            public const int UserFullNameMaxValue = 60;
        }

        public static class Car
        {
            public const int CarBrandMinValue = 1;
            public const int CarBrandMaxValue = 50;
            public const int CarModelMinValue = 1;
            public const int CarModelMaxValue = 50;
            public const int CarDescriptionMinValue = 10;
            public const int CarDescriptionMaxValue = 500;
            public const int CarImageUrlMinValue = 5;
            public const int CarImageUrlMaxValue = 300;
            public const string CarPriceMinValue = "0.0";
            public const string CarPriceMaxValue = "1000.0";
            public const int CarPricePrecision = 2;
            public const int CarPriceLength = 18;
            public const string CarPriceSQLDataType = "money";
        }

        public static class Dealer
        {
            public const int DealerNameMinValue = 2;
            public const int DealerNameMaxValue = 50;
            public const int DealerPhoneMinValue = 6;
            public const int DealerPhoneMaxValue = 15;
        }

        public static class Category
        {
            public const int CategoryNameMinValue = 2;
            public const int CategoryNameMaxValue = 50;
        }

        public static class City
        {
            public const int CityNameMinValue = 2;
            public const int CityNameMaxValue = 50;
        }

        public static class Dealership
        {
            public const int DealershipNameMinValue = 2;
            public const int DealershipNameMaxValue = 50;
            public const int DealershipAddressMinValue = 10;
            public const int DealershipAddressMaxValue = 100;
        }
    }
}

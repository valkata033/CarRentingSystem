namespace CarRentingSystem.Infrastructure.Data.GlobalConstants
{
    public static class DataConstants
    {
        public static class User
        {
            public const int UserEmailAddressMinValue = 8;
            public const int UserEmailAddressMaxValue = 30;

            public const int UserFullNameMinValue = 6;
            public const int UserFullNameMaxValue = 50;

            public const int UserNameMinValue = 2;
            public const int UserNameMaxValue = 40;

            public const int UserPasswordMinValue = 6;
            public const int UserPasswordMaxValue = 40;
        }

        public static class Car
        {
            public const int CarBrandMinValue = 1;
            public const int CarBrandMaxValue = 50;

            public const int CarModelMinValue = 1;
            public const int CarModelMaxValue = 50;

            public const int CarMakeYearMaxValue = 2022;
            public const int CarMakeYearMinValue = 1900;

            public const int CarDescriptionMinValue = 10;
            public const int CarDescriptionMaxValue = 500;

            public const int CarImageUrlMinValue = 5;
            public const int CarImageUrlMaxValue = 300;

            public const int CarPriceMinValue = 1;
            public const int CarPriceMaxValue = 1000;

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

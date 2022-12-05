namespace CarRentingSystem.Core.Contracts
{
    public interface ICarModel
    {
        public string Brand { get; }

        public string Model { get; }

        public int PricePerDay { get; }
    }
}

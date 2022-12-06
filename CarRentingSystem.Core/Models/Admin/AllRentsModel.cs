namespace CarRentingSystem.Core.Models.Admin
{
    public class AllRentsModel
    {
        public int Id { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public int Price { get; set; }

        public bool IsActive { get; set; }

    }
}

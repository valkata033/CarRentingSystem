using System.ComponentModel.DataAnnotations;

namespace CarRentingSystem.Infrastructure.Data.Models
{
    public class ReservationPeriod
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int Days { get; set; }

        [Required]
        public int Price { get; set; }

    }
}

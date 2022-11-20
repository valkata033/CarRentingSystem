using System.ComponentModel.DataAnnotations;

namespace CarRentingSystem.Infrastructure.Data.Models
{
    public class Reservation
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public DateTime StartDate { get; set; }

        [Required]
        public DateTime EndDate { get; set; }

        public IEnumerable<Car> Cars { get; set; } = new List<Car>();
    }
}

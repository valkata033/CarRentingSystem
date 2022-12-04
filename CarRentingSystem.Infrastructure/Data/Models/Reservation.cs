using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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

        [Required]
        public int Price { get; set; }

        [Required]
        public bool IsActive { get; set; }

        [Required]
        [ForeignKey(nameof(Car))]
        public int CarId { get; set; }
        public Car Car { get; set; } = null!;

        [Required]
        [ForeignKey(nameof(ReservationPeriod))]
        public int ReservationPeriodId { get; set; }
        public ReservationPeriod ReservationPeriod { get; set; } = null!;

    }
}

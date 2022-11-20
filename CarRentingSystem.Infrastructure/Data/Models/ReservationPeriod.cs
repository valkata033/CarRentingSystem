using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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

        [Required]
        [ForeignKey(nameof(Reservation))]
        public int ReservationId { get; set; }

        public Reservation Reservation { get; set; } = null!;

    }
}

using CarRentingSystem.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CarRentingSystem.Infrastructure.Data.Configuration
{
    internal class ReservationConfiguration : IEntityTypeConfiguration<Reservation>
    {
        public void Configure(EntityTypeBuilder<Reservation> builder)
        {
            builder.HasData(CreateReservations());
        }

        private List<Reservation> CreateReservations()
        {
            return new List<Reservation>()
            {
                new Reservation()
                {
                    Id = 1,
                    StartDate = DateTime.Now,
                    EndDate = DateTime.Now + TimeSpan.FromDays(5),
                    CarId = 1,
                    ReservationPeriodId = 2,
                }
            };
        }
    }
}

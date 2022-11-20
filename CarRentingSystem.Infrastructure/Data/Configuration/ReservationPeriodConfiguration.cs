using CarRentingSystem.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CarRentingSystem.Infrastructure.Data.Configuration
{
    internal class ReservationPeriodConfiguration : IEntityTypeConfiguration<ReservationPeriod>
    {
        public void Configure(EntityTypeBuilder<ReservationPeriod> builder)
        {
            builder.HasData(CreateReservationPeriods());
        }

        private List<ReservationPeriod> CreateReservationPeriods()
        {
            return new List<ReservationPeriod>()
            {
                new ReservationPeriod()
                {
                    Id = 1,
                    Days = 7,
                    Price = 200,
                    ReservationId = 1,
                }
            };
        }
    }
}

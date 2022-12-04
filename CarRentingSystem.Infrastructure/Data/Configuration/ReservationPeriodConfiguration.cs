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
                    Days = 3
                },
                new ReservationPeriod()
                {
                    Id = 2,
                    Days = 5
                },
                new ReservationPeriod()
                {
                    Id = 3,
                    Days = 10
                },
                new ReservationPeriod()
                {
                    Id = 4,
                    Days = 30
                }
            };
        }
    }
}

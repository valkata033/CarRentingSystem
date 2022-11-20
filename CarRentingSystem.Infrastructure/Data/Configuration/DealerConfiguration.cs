using CarRentingSystem.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CarRentingSystem.Infrastructure.Data.Configuration
{
    internal class DealerConfiguration : IEntityTypeConfiguration<Dealer>
    {   
        public void Configure(EntityTypeBuilder<Dealer> builder)
        {
            builder.HasData(CreateDealers());
        }

        private List<Dealer> CreateDealers()
        {
            var dealers = new List<Dealer>();


            return dealers;
        }
    }
}

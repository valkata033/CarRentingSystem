using CarRentingSystem.Infrastructure.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CarRentingSystem.Infrastructure.Data.Configuration
{
    internal class UserConfiguration : IEntityTypeConfiguration<ApplicationUser>
    {
        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            builder.HasData(CreateUsers());
        }

        private List<ApplicationUser> CreateUsers()
        {
            var users = new List<ApplicationUser>();
            var hasher = new PasswordHasher<ApplicationUser>();

            var user = new ApplicationUser()
            {
                Id = "dea12856-c198-4129-b3f3-b893d8395082",
                UserName = "dealer@mail.com",
                NormalizedUserName = "dealer@mail.com",
                Email = "dealer@mail.com",
                NormalizedEmail = "dealer@mail.com",
                FullName = "Dealer",
                IsActive = true,
            };

            user.PasswordHash = hasher.HashPassword(user, "dealer123");
            users.Add(user);

            user = new ApplicationUser()
            {
                Id = "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                UserName = "guest@mail.com",
                NormalizedUserName = "guest@mail.com",
                Email = "guest@mail.com",
                NormalizedEmail = "guest@mail.com",
                FullName = "Guest",
                IsActive = true,
            };

            user.PasswordHash = hasher.HashPassword(user, "guest123");
            users.Add(user);

            user = new ApplicationUser()
            {
                Id = "4078b0fd-3914-461c-8c6b-06bda682647d",
                UserName = "dealer123",
                FullName = "Luxury Dealer",
                Email = "LuxuryDealer@abv.bg",
                NormalizedEmail = "LuxuryDealer@abv.bg",
                NormalizedUserName = "dealer123",
                IsActive = true,
            };

            user.PasswordHash = hasher.HashPassword(user, "Dealer123");
            users.Add(user);

            user = new ApplicationUser()
            {
                Id = "bcc313a0-a38a-42a2-a42c-d00f09a89c5f",
                UserName = "Admin",
                NormalizedUserName = "ADMIN",
                FullName = "Georgi Peshev",
                Email = "gosho123@abv.bg",
                NormalizedEmail = "GOSHO123@ABV.BG",
                IsActive = true,
            };

            user.PasswordHash = hasher.HashPassword(user, "Gosho123");
            users.Add(user);

            return users;
        }
    }
}

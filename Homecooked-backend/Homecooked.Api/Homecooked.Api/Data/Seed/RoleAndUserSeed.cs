using Homecooked.Api.Models;
using Homecooked.Api.Models.Enums;
using Homecooked.Api.Helpers;
using Microsoft.EntityFrameworkCore;

namespace Homecooked.Api.Data.Seed
{
    public static class RoleAndUserSeed
    {
        public static void Seed(ApplicationDbContext context)
        {
            if (!context.Users.Any())
            {
                var adminUser = new User
                {
                    Id = Guid.NewGuid(),
                    FullName = "System Admin",
                    Email = "admin123@gmail.com",
                    PasswordHash = PasswordHasher.HashPassword("Admin@123"),
                    Role = UserRole.ADMIN,
                    IsActive = true,
                    IsVerified = true,
                    CreatedAt = DateTime.UtcNow
                };

                context.Users.Add(adminUser);
                context.SaveChanges();
            }
        }
    }
}

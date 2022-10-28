using LP304_Takt.Models;
using LP304_Takt.Shared;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;

namespace LP304_Takt.Data
{
    public class SeedData
    {
        public static async Task CreateAdminOnStartup(DataContext context)
        {
            var hmac = new HMACSHA512();
            var password = "admin123";
            var admin = new User
            {
                FirstName = "Admin",
                LastName = "Admin",
                Email = "admin@admin.com",
                Role = Role.Admin,
                PasswordSalt = hmac.Key,
                PasswordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password)),
                //VerificationToken = Convert.ToHexString(RandomNumberGenerator.GetBytes(64)),
                VerifiedAt = DateTime.Now
            };
            context.Database.Migrate();
            if (context.Users.Any()) return;

            context.Users.Add(admin);
            await context.SaveChangesAsync();
        }
    }
}

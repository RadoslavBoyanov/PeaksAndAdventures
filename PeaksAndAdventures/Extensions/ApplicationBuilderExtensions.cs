using Microsoft.AspNetCore.Identity;
using static PeaksAndAdventures.Common.Constants;

namespace Microsoft.AspNetCore.Builder
{
    public static class ApplicationBuilderExtensions
    {
        public static async Task ConfigureRolesAndAdmin(this IApplicationBuilder app)
        {
            using var scope = app.ApplicationServices.CreateScope();
            var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            var userManager = scope.ServiceProvider.GetRequiredService<UserManager<IdentityUser>>();

            string[] roles = { AdminRole, AmateurMountaineerRole, MountaineerRole, TourAgencyRole };

            // Create roles
            foreach (var role in roles)
            {
                if (await roleManager.RoleExistsAsync(role) == false)
                {
                    var newRole = new IdentityRole(role);
                    roleManager.CreateAsync(newRole).Wait();
                }
            }

            // Create admin user
            string adminEmail = "adminPower@gmail.com";
            string adminPassword = "Boss111!";

            var adminUser = await userManager.FindByEmailAsync(adminEmail);
            if (adminUser == null)
            {
                var admin = new IdentityUser { UserName = adminEmail, Email = adminEmail };

                // Hash the password
                var passwordHasher = new PasswordHasher<IdentityUser>();
                var hashedPassword = passwordHasher.HashPassword(admin, adminPassword);

                admin.PasswordHash = hashedPassword;

                // Create the admin user
                var result = userManager.CreateAsync(admin).Result;
                if (result.Succeeded)
                {
                    // Add the admin user to the Admin role
                    await userManager.AddToRoleAsync(admin, AdminRole);
                }
                else
                {
                    // Error handling
                    foreach (var error in result.Errors)
                    {
                        Console.WriteLine($"Error: {error.Description}");
                    }
                }
            }
        }

    }
}

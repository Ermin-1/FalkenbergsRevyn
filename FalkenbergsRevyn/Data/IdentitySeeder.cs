using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading.Tasks;

namespace FalkenbergsRevyn.Data
{
    public class IdentitySeeder
    {
        public static async Task SeedRolesAndAdminUser(IServiceProvider serviceProvider)
        {
            var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            var userManager = serviceProvider.GetRequiredService<UserManager<IdentityUser>>();

            // Definiera roller som ska skapas
            string[] roleNames = { "Admin", "User" };

            // Skapa roller om de inte redan finns
            foreach (var roleName in roleNames)
            {
                var roleExist = await roleManager.RoleExistsAsync(roleName);
                if (!roleExist)
                {
                    await roleManager.CreateAsync(new IdentityRole(roleName));
                }
            }

            // Skapa en administratörsanvändare om den inte redan finns
            var adminUser = await userManager.FindByEmailAsync("admin@example.com");
            if (adminUser == null)
            {
                adminUser = new IdentityUser()
                {
                    UserName = "admin@example.com",
                    Email = "admin@example.com",
                    EmailConfirmed = true // Ställ in EmailConfirmed till true
                };

                string adminPassword = "Admin@123"; // Ange ett starkt lösenord
                var createAdminUser = await userManager.CreateAsync(adminUser, adminPassword);
                if (createAdminUser.Succeeded)
                {
                    // Tilldela Admin-rollen till användaren
                    await userManager.AddToRoleAsync(adminUser, "Admin");
                }
            }
            else
            {
                // Om adminanvändaren redan finns, kontrollera om EmailConfirmed är satt till false och uppdatera om så är fallet
                if (!adminUser.EmailConfirmed)
                {
                    adminUser.EmailConfirmed = true;
                    await userManager.UpdateAsync(adminUser);
                }
            }
        }
    }
}

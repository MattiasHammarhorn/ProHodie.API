using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ProHodie.API.Configuration;
using ProHodie.API.Models.Entities;

namespace ProHodie.API
{
    public static class IdentitySeed
    {
        public static async Task EnsureRolesAndUsers(IServiceProvider serviceProvider, IdentitySeedSettings seedSettings)
        {
            RoleManager<ApplicationRole> roleManager = serviceProvider.GetRequiredService<RoleManager<ApplicationRole>>();
            UserManager<ApplicationUser> userManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();

            string[] roles = new string[] { "SuperAdmin", "Admin", "User" };

            foreach (var role in roles)
            {
                var existingRole = await roleManager.FindByNameAsync(role);
                if (existingRole == null)
                {
                    await roleManager.CreateAsync(new ApplicationRole { Name = role });
                }
            }

            var userEmail = seedSettings.userEmail;
            var userPassword = seedSettings.userPassword;

            var existingUser = await userManager.FindByEmailAsync(userEmail);
            if (existingUser == null)
            {
                var superAdmin = new ApplicationUser
                {
                    UserName = "SuperAdministrator",
                    Email = userEmail,
                    EmailConfirmed = true
                };

                await userManager.CreateAsync(superAdmin, userPassword);
                await userManager.AddToRoleAsync(superAdmin, "SuperAdmin");
            }
        }
    }
}

using System;
using System.Linq;
using System.Threading.Tasks;
using Data.Domain.Entities;
using Microsoft.AspNetCore.Identity;

namespace Data.Persistence
{
    public class DbSeeder
    {
        public static void Seed(
            DatabaseContext dbContext,
            RoleManager<IdentityRole> roleManager,
            UserManager<User> userManager
            )
        {
            // Create default Users (if there are none)
            if (!dbContext.Users.Any())
            {
                CreateUsers(dbContext, roleManager, userManager)
                    .GetAwaiter()
                    .GetResult();
            }
        }

        private static async Task CreateUsers(
            DatabaseContext dbContext,
            RoleManager<IdentityRole> roleManager,
            UserManager<User> userManager)
        {
            // local variables
            DateTime createdDate = new DateTime(2016, 03, 01, 12, 30, 00);
            DateTime lastModifiedDate = DateTime.Now;

            string role_Administrator = "Administrator";
            string role_RegisteredUser = "RegisteredUser";

            //Create Roles (if they doesn't exist yet)
            if (!await roleManager.RoleExistsAsync(role_Administrator))
            {
                await roleManager.CreateAsync(new IdentityRole(role_Administrator));
            }
            if (!await roleManager.RoleExistsAsync(role_RegisteredUser))
            {
                await roleManager.CreateAsync(new IdentityRole(role_RegisteredUser));
            }

            // Create the "Admin" ApplicationUser account
            var userAdmin = User.Create("Admin", "Admin", "admin@skillpoint.com", "Wherever", null);
            // Insert "Admin" into the Database and assign the "Administrator" and "Registered" roles to him.
            if (await userManager.FindByIdAsync(userAdmin.Id) == null)
            {
                await userManager.CreateAsync(userAdmin, "Pass4Admin");
                await userManager.AddToRoleAsync(userAdmin, role_RegisteredUser);
                await userManager.AddToRoleAsync(userAdmin, role_Administrator);
                // Remove Lockout and E-Mail confirmation.
                userAdmin.EmailConfirmed = true;
                userAdmin.LockoutEnabled = false;
            }
            await dbContext.SaveChangesAsync();
        }
    }
}
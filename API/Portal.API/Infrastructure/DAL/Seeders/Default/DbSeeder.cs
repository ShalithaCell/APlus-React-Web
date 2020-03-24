using Microsoft.AspNetCore.Identity;
using Portal.API.Domain.IdentityModel;
using Portal.API.Infrastructure.DAL.DatabaseContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Portal.API.Infrastructure.DAL.Seeders.Default
{
    public static class DbSeeder
    {
        public static void SeedDb(ApplicationDbContext context, RoleManager<AppRole> roleManager)
        {
            SeedRole(roleManager);
        }

        //Adding default roles
        private static void SeedRole(RoleManager<AppRole> roleManager)
        {
            AppRole appRoleSuperAdmin = new AppRole()
            {
                Name = "SuperAdministrator",
                DisplayName = "Super Administrator",
                OrganizationID = 1
            };

            AppRole appRoleAdmin = new AppRole()
            {
                Name = "Administrator",
                DisplayName = "Administrator",
                OrganizationID = 1
            };

            AppRole appRoleAuthenticatedUser = new AppRole()
            {
                Name = "AuthenticatedUser",
                DisplayName = "Authenticated User",
                OrganizationID = 1
            };

            roleManager.CreateAsync(appRoleSuperAdmin).Wait();
            roleManager.CreateAsync(appRoleAdmin).Wait();
            roleManager.CreateAsync(appRoleAuthenticatedUser).Wait();

        }

        public static void SeedUsers(UserManager<AppUser> userManager)
        {
            if (userManager.FindByEmailAsync("shalithax@gmail.com").Result == null)
            {
                AppUser user = new AppUser
                {
                    UserName = "shalithax@gmail.com",
                    Email = "shalithax@gmail.com",
                    EmailConfirmed = true
                };

                IdentityResult result = userManager.CreateAsync(user, "Mvc@2018").Result;

                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(user, "SuperAdministrator").Wait();
                }
            }
        }

    }
}

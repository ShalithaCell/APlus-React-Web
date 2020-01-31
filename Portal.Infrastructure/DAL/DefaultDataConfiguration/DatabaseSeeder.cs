using Microsoft.AspNetCore.Identity;
using Portal.Domain.IdentityModels;
using Portal.Infrastructure.DAL.DatabaseContext;
using System;
using System.Collections.Generic;
using System.Text;

namespace Portal.Infrastructure.DAL.DefaultDataConfiguration
{
    /// <summary>
    /// Seeding the data with database while migrating. All concrete data are apply to database from here.
    /// </summary>
    public class DatabaseSeeder
    {
        /// <summary>
        /// public method for put all seeding activities
        /// </summary>
        /// <param name="context"></param>
        /// <param name="roleManager"></param>
        public static void SeedDb(ApplicationDbContext context, RoleManager<AppRole> roleManager)
        {
            SeedRole(roleManager);
            //add new seeding method in below

        }

        /// <summary>
        /// Seeding the default roles
        /// </summary>
        /// <param name="roleManager"></param>
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
    }
}

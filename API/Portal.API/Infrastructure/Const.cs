using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Portal.API.Infrastructure
{
    public static class Const
    {
        /// <summary>
        /// Access control const
        /// </summary>
        public const string RoleSuperAdmin = "1";
        public const string RoleAdmin = "Administrator";
        public const string RoleAdminOrSuperAdmin = RoleSuperAdmin + "," + RoleAdmin;
    }
}

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
        public const string RoleAdmin = "2";
        public const string AuthenticatedUser = "3";

        public const string RoleAdminOrSuperAdmin = RoleSuperAdmin + "," + RoleAdmin;
        public const string RoleAdminOrSuperAdminOrAuthUser = RoleSuperAdmin + "," + RoleAdmin + "," + AuthenticatedUser;
    }
}

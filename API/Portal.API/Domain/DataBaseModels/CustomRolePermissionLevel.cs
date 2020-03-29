using Portal.API.Domain.BaseModels;
using Portal.API.Domain.IdentityModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Portal.API.Domain.DataBaseModels
{
    public class CustomRolePermissionLevelc : BaseEntity
    {
        public int FK_CustomPermisson { get; set; }

        public int FK_RoleID { get; set; }

        public bool Allowed { get; set; }

        public AppRole appRole { get; }
        public CustomPermission customPermission { get; }
    }
}

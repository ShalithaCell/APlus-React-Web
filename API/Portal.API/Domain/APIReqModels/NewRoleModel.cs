using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Portal.API.Domain.APIReqModels
{
    public class NewRoleModel
    {
        [Required(ErrorMessage = "Role Name is Required")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Role Display nAme is Required")]
        public string DisplayName { get; set; }

        [Required(ErrorMessage = "Organization ID is Required")]
        public int OrgID { get; set; }

        public List<RolePermissionLevel> RolePermissionLevels { get; set; }
    }

    public class RolePermissionLevel
    {
        public int CustomPermissonID { get; set; }
        public bool Allowed { get; set; }

    }
}

using Microsoft.AspNetCore.Identity;
using Portal.API.Domain.DataBaseModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Portal.API.Domain.IdentityModel
{
    public class AppRole : IdentityRole<int>
    {
        public int OrganizationID { get; set; }

        [Required(ErrorMessage = "Display name is Required.")]
        [MaxLength(100, ErrorMessage = "Please enter Display name less than 100 characters.")]
        public string DisplayName { get; set; }

        [Required(ErrorMessage = "Editable flag is Required.")]
        public bool Editable { get; set; }

        [ForeignKey("FK_RoleID")]
        public ICollection<CustomRolePermissionLevelc> customRolePermissionLevels { get; set; }
    }
}

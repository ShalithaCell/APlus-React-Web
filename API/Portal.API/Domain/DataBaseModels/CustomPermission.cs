using Portal.API.Domain.BaseModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Portal.API.Domain.DataBaseModels
{
    public class CustomPermission : BaseEntity
    {
        public string PermissionCode { get; set; }
        public string Permission { get; set; }

        [ForeignKey("FK_CustomPermisson")]
        public ICollection<CustomRolePermissionLevelc> customRolePermissionLevels { get; set; }
    }
}

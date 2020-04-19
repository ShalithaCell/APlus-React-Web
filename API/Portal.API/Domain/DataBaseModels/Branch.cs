using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Portal.API.Domain.BaseModels;

namespace Portal.API.Domain.DataBaseModels
{
    public class Branch : BaseEntity
    {
        [Required]
        public string BranchName { get; set; }

        [Required]
        public string OrgName { get; set; }

        [Required]
        public string BranchLocation { get; set; }

        [Required]
        public string BranchPhone { get; set; }

        [Required]
        public int NoofEmployees { get; set; }

        public Organization Organization { get; set; }

        public int OrganizationFK { get; set; }
        
    }
}
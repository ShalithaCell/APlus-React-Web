using Portal.API.Domain.BaseModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Portal.API.Domain.DataBaseModels
{
    public class Organization : BaseEntity
    {
        [Required]
        public string OrgName { get; set; }

        [Required]
        public string OrgLocation { get; set; }
        public ICollection<Branch> Branch { get; set; }
    }
}

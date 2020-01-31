using Microsoft.AspNetCore.Identity;
using Portal.Domain.DatabaseModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Portal.Domain.IdentityModels
{
    public class AppUser : IdentityUser<int>
    {
        [Required]
        public int OrganizationID { get; set; }

        [ForeignKey("OrganizationID")]
        public Organization Organization { get; set; }
    }
}

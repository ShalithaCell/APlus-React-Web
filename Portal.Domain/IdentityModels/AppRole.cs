using Microsoft.AspNetCore.Identity;
using Portal.Domain.DatabaseModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Portal.Domain.IdentityModels
{
    public class AppRole : IdentityRole<int>
    {
        [Required]
        public int OrganizationID { get; set; }

        [Required(ErrorMessage = "Display name is Required.")]
        [MaxLength(100, ErrorMessage = "Please enter Display name less than 100 characters.")]
        public string DisplayName { get; set; }

        [ForeignKey("OrganizationID")]
        public Organization Organization { get; set; }
    }
}

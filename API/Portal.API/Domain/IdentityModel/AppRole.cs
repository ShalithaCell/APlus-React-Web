using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
    }
}

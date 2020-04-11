using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Portal.API.Domain.APIReqModels
{
    public class NewUserInputModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
        [Display(Name = "Password")]
        public string Password { get; set; }


        [Required]
        [Display(Name = "Role")]
        public string RoleID { get; set; }

        [Required]
        [Display(Name = "User name")]
        public string UserName { get; set; }

        public string PhoneNumber { get; set; }

        [Required]
        public int OrgID { get; set; }

        [Required]
        public string BaseUrl { get; set; }
    }

    public class UpdateUpdateModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }
        public string Password { get; set; }


        [Required]
        [Display(Name = "Role")]
        public string RoleID { get; set; }

        public string PhoneNumber { get; set; }


    }
}

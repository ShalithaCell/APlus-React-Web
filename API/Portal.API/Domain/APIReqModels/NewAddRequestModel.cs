using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Portal.API.Domain.APIReqModels
{
    public class NewAddRequestModel
    {

        [Required(ErrorMessage = "First Name is Required")]
        public string fname { get; set; }

        [Required(ErrorMessage = "Last Name is Required")]
        public string lname { get; set; }

        [Required(ErrorMessage = "Email is Required")]
        public string email { get; set; }

        [Required(ErrorMessage = "Address is Required")]
        public string address { get; set; }

        [Required(ErrorMessage = "Phone Number is Required")]
        public string phoneno { get; set; }

        [Required(ErrorMessage = "Role name is Required")]
        public string role { get; set; }
       
    }
}

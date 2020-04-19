using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Portal.API.Domain.APIReqModels
{
    public class CustomerModel
    {
        [Required( ErrorMessage = "Frist Name is Required")]
        public String Fname { get; set; }

        [Required(ErrorMessage = "Last Name is Required")]
        public String Lname { get; set; }

        [Required(ErrorMessage = "Email is Required")]
        public String Email { get; set; }

        [Required(ErrorMessage = "ID Number is Required")]
        public int Id_number { get; set; }

        [Required(ErrorMessage = "Phone Number is Required")]
        public int Phone_number { get; set; }
    }
}

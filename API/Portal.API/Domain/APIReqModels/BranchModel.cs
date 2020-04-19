using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Portal.API.Domain.APIReqModels
{
    public class BranchModel
    {
        [Required(ErrorMessage = "Branch Name is Required")]
        public string B_Name { get; set; }

        [Required(ErrorMessage = "Organization Name is Required")]
        public string Org_Name { get; set; }

        [Required(ErrorMessage = "Location is Required")]
        public string B_Location { get; set; }

        [Required(ErrorMessage = "Phone Number is Required")]
        public string B_Phone { get; set; }

        [Required(ErrorMessage = "Phone Number is Required")]
        public int B_Employee { get; set; }
    }

    public class GetBranchInfo
    {
        [Required]
        public int B_Id { get; set; }
    }
}
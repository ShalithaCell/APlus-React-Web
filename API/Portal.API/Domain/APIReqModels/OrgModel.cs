using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Portal.API.Domain.APIReqModels
{
    public class OrgModel
    {
        [Required(ErrorMessage = "Organization Name is Required")]
        public string Org_Name { get; set; }

        [Required(ErrorMessage = "Location is Required")]
        public string Org_Location { get; set; }
        public int Id { get; internal set; }
    }
}

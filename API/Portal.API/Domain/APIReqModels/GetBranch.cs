using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Xunit.Sdk;

namespace Portal.API.Domain.APIReqModels
{
    public class GetBranch
    {

        public class GetBranchInfo
        {
            [Required(ErrorMessage = "Role ID is required.")]
            public int RoleID { get; set; }
        }
    }
}

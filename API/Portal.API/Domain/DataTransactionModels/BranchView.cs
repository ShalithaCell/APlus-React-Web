using Portal.API.Domain.IdentityModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Portal.API.Domain.DataTransactionModels
{
    public class BranchView
    {

        public string BranchName { get; set; }


        public string OrgName { get; set; }

        public string BranchLocation { get; set; }

        public string BranchPhone { get; set; }

        public int NoofEmployees { get; set; }
        public int Id { get; set; }

        
    }
}

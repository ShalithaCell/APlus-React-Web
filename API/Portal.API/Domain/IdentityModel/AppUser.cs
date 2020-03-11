using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Portal.API.Domain.IdentityModel
{
    public class AppUser : IdentityUser<int>
    {
        public int OrganizationID { get; set; }
    }
}

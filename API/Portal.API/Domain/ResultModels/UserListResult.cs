using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Portal.API.Domain.ResultModels
{
    public class UserListResult
    {
        public int ID { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public int RoleID { get; set; }
        public string RoleName { get; set; }
        public bool modifyAllowed {get;set;}
        public string Locked { get; set; }
        public string Phone { get; set; }

    }
}

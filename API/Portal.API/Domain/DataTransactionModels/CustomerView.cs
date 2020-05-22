using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Portal.API.Domain.DataTransactionModels
{
    public class CustomerView
    { 
        public String fname { get; set; }

        
        public String lname { get; set; }

        
        public String email { get; set; }

        
        public int id_number { get; set; }

        public int phone_number { get; set; }

        public int Id { get; set; }
    }
}

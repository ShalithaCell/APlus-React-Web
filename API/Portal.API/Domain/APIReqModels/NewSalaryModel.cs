using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Portal.API.Domain.APIReqModels
{
    public class NewSalaryModel
    {
        [Required(ErrorMessage = "Fullname is required.")]
        public String name { get; set; }
        public String designation { get; set; }
        [Required(ErrorMessage = "Employee Id is required.")]
        public String eid { get; set; }
        public Double basic { get; set; }
        public Double bonus { get; set; }
        public int attendance { get; set; }
        [Required(ErrorMessage = "Salary Month is required.")]
        public String for_month { get; set; }
        [Required(ErrorMessage = "Total is required.")]
        public Double total { get; set; }

    }
}

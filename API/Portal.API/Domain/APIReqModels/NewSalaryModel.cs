using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Portal.API.Domain.APIReqModels
{
    public class NewSalaryModel
    {
        [Required(ErrorMessage = "Salary Id is required.")]
        public String salary_ID { get; set; }
        [Required(ErrorMessage = "Fullname is required.")]
        public String name { get; set; }
        [Required(ErrorMessage = "Employee Id is required.")]
        public String eid { get; set; }
        public Double basic { get; set; }
        public Double bonus { get; set; }
        public int attendance { get; set; }
        [Required(ErrorMessage = "Pay date is required.")]
        public DateTime paid_date { get; set; }
        [Required(ErrorMessage = "Salary Month is required.")]
        public DateTime for_month { get; set; }
        [Required(ErrorMessage = "Total is required.")]
        public Double total { get; set; }

    }
}

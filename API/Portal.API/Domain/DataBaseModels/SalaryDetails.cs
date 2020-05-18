using Portal.API.Domain.BaseModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Portal.API.Domain.DataBaseModels
{
    public class SalaryDetails : BaseEntity
    {
        [Required]
        public String Name { get; set; }
        [Required]
        public String Designation { get; set; }
        [Required]
        public String Eid { get; set; }
        public Double Basic { get; set; }
        public Double Bonus { get; set; } 
        public int Attendance { get; set; }
        [Required]
        public String For_month { get; set; }
        [Required]
        public Double Total { get; set; } 

    }
}

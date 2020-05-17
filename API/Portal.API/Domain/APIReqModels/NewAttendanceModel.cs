using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Portal.API.Domain.APIReqModels
{
    public class NewAttendanceModel
    {
        [Required(ErrorMessage = "Name is Required")]
        public string name { get; set; }

        [Required(ErrorMessage = "Name is Required")]
        public string role { get; set; }

        [Required(ErrorMessage = "ClockOnTime is Required")]
        public DateTime onTime { get; set; }

        [Required(ErrorMessage = "ClockOutTime is Required")]
        public DateTime outTime { get; set; }

        [Required(ErrorMessage = "WorkingHours is Required")]
        public DateTime wHours { get; set; }

       
    }
}

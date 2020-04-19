using Portal.API.Domain.BaseModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Portal.API.Domain.DataBaseModels
{
    public class Attendances: BaseEntity
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [Required]
        public DateTime ClockOnTime { get; set; }


        [Required]
        public DateTime ClockOutTime { get; set; }

        [Required]
        public DateTime WorkingHours { get; set; }

       
    }
}

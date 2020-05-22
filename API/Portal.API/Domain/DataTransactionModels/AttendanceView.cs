using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Portal.API.Domain.DataTransactionModels
{
    public class AttendanceView
    {
        
        public string Name { get; set; }

        public string Role { get; set; }

        public DateTime ClockOnTime { get; set; }
    
        public DateTime ClockOutTime { get; set; }

        
        public DateTime WorkingHours { get; set; }

        public int Id { get; set; }
    }
}


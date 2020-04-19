using Portal.API.Domain.BaseModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Portal.API.Domain.DataBaseModels
{
    public class customer: BaseEntity
    {
        [Required]
        public String fname { get; set; }

        [Required]
        public String lname { get; set; }

        [Required]
        public String email { get; set; }

        [Required]
        [MaxLength(12)]
        public  int id_number { get; set; }

        [Required]
        [MaxLength(10)]
        public int phone_number { get; set; }


    }
}

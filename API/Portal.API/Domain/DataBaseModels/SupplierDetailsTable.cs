using Portal.API.Domain.BaseModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Portal.API.Domain.DataBaseModels
{
    public class SupplierDetailsTable : BaseEntity
    {
        [Required]
        public string fname { get; set; }

        [Required]
        public string lname { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string category { get; set; }

        [Required]
        public string area { get; set; }

        [Required]
        public int phoNumber { get; set; }
       
    }
}

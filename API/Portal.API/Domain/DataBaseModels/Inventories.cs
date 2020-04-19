using Portal.API.Domain.BaseModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Portal.API.Domain.DataBaseModels
{
    public class Inventories : BaseEntity
    {
        [Required]
        public string ProductName { get; set; }

        [Required]
        public string ProductCode { get; set; }

        [Required]
        public int Qty { get; set; }

        [Required]
        public double UnitPrice { get; set; }

        [Required]
        public string SupplireName { get; set; }

        [Required]
        public string SupplireEmail { get; set; }
    }
}

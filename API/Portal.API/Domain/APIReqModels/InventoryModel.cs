using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Portal.API.Domain.APIReqModels
{
    public class InventoryModel
    {
        [Required(ErrorMessage = "Product Name is Required")]
        public string PName { get; set; }

        [Required(ErrorMessage = "Product Code is Required")]
        public string Pcode { get; set; }

        [Required(ErrorMessage = "Quantity is Required")]
        public int Qty_ { get; set; }

        [Required(ErrorMessage = "Unit Price is Required")]
        public int Uprice { get; set; }

        [Required(ErrorMessage = "Supplire name is Required")]
        public string SName { get; set; }

        [Required(ErrorMessage = "Supplire email is Required")]
        public string SEmail { get; set; }
    }
}

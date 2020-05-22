using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Portal.API.Domain.APIReqModels
{
    public class SupplierModel
    {
        [Required(ErrorMessage = "First Name is Required")]
        public string Finame { get; set; }

        [Required(ErrorMessage = "Last Name is Required")]
        public string Laname { get; set; }

        [Required(ErrorMessage = "Email is Required")]
        public string email { get; set; }

        [Required(ErrorMessage = "Category is Required")]
        public string CAtegory { get; set; }

        [Required(ErrorMessage = "Area  is Required")]
        public string ARea { get; set; }

        [Required(ErrorMessage = "Phone Number  is Required")]
        public int PHoNumber { get; set; }

        public int ID { get; set; }
    }
}

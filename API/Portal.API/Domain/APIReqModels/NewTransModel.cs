using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Portal.API.Domain.APIReqModels
{
    public class NewTransModel
    {

        [Required(ErrorMessage = "Transaction Id is required.")]
        public String transaction_ID { get; set; }
        public String description { get; set; }
        [Required(ErrorMessage = "User Id is required.")]
        public String user_ID { get; set; }
        [Required(ErrorMessage = "Date is required.")]
        public DateTime date { get; set; }
        [Required(ErrorMessage = "Time Id is required.")]
        public DateTime time { get; set; }
        public int quantity { get; set; }
        public Double unit_price { get; set; }
        [Required(ErrorMessage = "Total Id is required.")]
        public Double total { get; set; }
    }
}

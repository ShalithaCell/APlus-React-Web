using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Portal.API.Domain.APIReqModels
{
    public class NewTransactionModel
    {

            public String Description { get; set; }
            [Required(ErrorMessage = "User Id is required.")]
            public String User_ID { get; set; }
            public int Quantity { get; set; }
            public Double Unit_price { get; set; }
            [Required(ErrorMessage = "Total Id is required.")]
            public Double Total { get; set; }
    }
    public class TransactionInfoReqData
    {
        [Required(ErrorMessage = "Transaction ID is required.")]
        public int Transaction_ID { get; set; }
    }
}

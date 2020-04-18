using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Portal.API.Domain.APIReqModels
{
    public class CashierModel
    {
        public string description { get; set; }

        public int qty { get; set; }

        public double unitPrice { get; set; }

        public double sum { get; set; }

        public double subTotal { get; set; }

        public decimal discount { get; set; }

        public double total { get; set; }

    }

}

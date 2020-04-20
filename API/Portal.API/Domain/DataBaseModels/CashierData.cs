using Portal.API.Domain.BaseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Portal.API.Domain.DataBaseModels
{
    public class CashierData : BaseEntity
    {
        public string Description { get; set; }

        public int Qty { get; set; }

        public double UnitPrice { get; set; }

        public double Sum { get; set; }

        public double SubTotal { get; set; }

        public decimal Discount { get; set; }

        public double Total { get; set; }
    }
}

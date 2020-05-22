using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Portal.API.Domain.DataTransactionModels
{
    public class InventoryView
    {
        public string PName { get; set; }
        public string Pcode { get; set; }
        public int Qty_ { get; set; }
        public int Uprice { get; set; }
        public string SName { get; set; }
        public string SEmail { get; set; }
        public int ID { get; set; }

    }
}

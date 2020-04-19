using Portal.API.Domain.BaseModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Portal.API.Domain.DataBaseModels
{
    public class TransactionDetails : BaseEntity
    {   
        [Required]
        public String Transaction_ID { get; set; }
        public String Description { get; set; }
        [Required]
        public String User_ID { get; set; }
        [Required]
        public DateTime Date { get; set; }
        [Required]
        public DateTime Time { get; set; }
        public int Quantity { get; set; }
        public Double Unit_price { get; set; }
        [Required]
        public Double Total { get; set; }

    }
}

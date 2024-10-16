using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models.Request
{
    public class SaleCreateRequest
    {
        public DateTime DateTime { get; set; }
        public int TotalSaleAmount { get; set; }
        public string ProductSale {  get; set; }
        public int Amount { get; set; }

    }
}

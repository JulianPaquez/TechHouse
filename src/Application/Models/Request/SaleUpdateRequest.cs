﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models.Request
{
    public class SaleUpdateRequest
    {
        public DateTime DateTime { get; set; }
        public decimal TotalSaleAmount { get; set; }
        public string ProductSale { get; set; }
        public decimal Amount { get; set; }

    }
}

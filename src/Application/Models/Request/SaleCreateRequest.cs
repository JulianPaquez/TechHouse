using System;
using System.Collections.Generic;

namespace Application.Models.Request
{
    public class SaleCreateRequest
    {
        public DateTime DateTime { get; set; }
        public List<ProductSaleRequest> ProductSales { get; set; }

        public SaleCreateRequest()
        {
            ProductSales = new List<ProductSaleRequest>();
        }
    }

    public class ProductSaleRequest
    {
        public string Name { get; set; }
        public int Stock { get; set; }
    }
}

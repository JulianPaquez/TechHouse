using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models
{
    public class SaleDto
    {
        public int Id { get; set; }
        public DateTime DateTime { get; set; }
        public int TotalSaleAmount { get; set; }
        public string ProductSale { get; set; }
        public int Amount { get; set; }

        public static SaleDto Create(Sale sale) 
        {
            return new SaleDto
            {
                Id = sale.Id,
                DateTime = sale.DateTime,
                TotalSaleAmount = sale.TotalSaleAmount,
                ProductSale = sale.ProductSale,
                Amount = sale.Amount,
            };

        }
        public static List<SaleDto> CreateList(IEnumerable<Sale> sales)
        {

            return sales.Select(s => Create(s)).ToList();
        }
    }

}

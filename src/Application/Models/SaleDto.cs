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
        public decimal TotalSaleAmount { get; set; } = 0;
        // public string ProductSale { get; set; }

        // public ICollection<SaleDetails> ? SaleDetails { get; set; } 
        

        public static SaleDto Create(Sale sale) 
        {
            return new SaleDto
            {
                Id = sale.Id,
                DateTime = sale.DateTime,
                TotalSaleAmount = sale.TotalSaleAmount,
                // ProductSale = sale.ProductSale,
                // SaleDetails = sale.SaleDetails,
            };

        }
        public static List<SaleDto> CreateList(IEnumerable<Sale> sales)
        {

            return sales.Select(s => Create(s)).ToList();
        }
    }

}

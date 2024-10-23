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
        public decimal TotalSaleAmount { get; set; }
        public string ProductSale { get; set; }
        public decimal Amount { get; set; }
        public ICollection<SaleDetails> SaleDetails { get; set; }

        public static SaleDto Create(Sale sale) 
        {
            return new SaleDto
            {
                Id = sale.Id,
                DateTime = sale.DateTime,
                TotalSaleAmount = sale.TotalSaleAmount,
                ProductSale = sale.ProductSale,
                Amount = sale.Amount,
                SaleDetails = sale.SaleDetails != null ? SaleDetailsDto.CreateList(sale.SaleDetails) : null
            };

        }
        public static List<SaleDto> CreateList(IEnumerable<Sale> sales)
        {

            return sales.Select(s => Create(s)).ToList();
        }
    }

}

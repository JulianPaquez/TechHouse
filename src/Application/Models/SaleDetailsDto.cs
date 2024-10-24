using Domain.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Application.Models
{
    public class SaleDetailsDto
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int SaleId { get; set; }
        public int ProductId { get; set; }

        // Información básica del producto y venta
        public string ProductName { get; set; }
        public decimal ProductPrice { get; set; }
        public int Stock { get; set; }
        public decimal TotalAmount { get; set; }

        public static SaleDetailsDto Create(SaleDetails saleDetails)
        {
            return new SaleDetailsDto
            {
                Id = saleDetails.Id,
                SaleId = saleDetails.SaleId,
                ProductId = saleDetails.ProductId,
                ProductName = saleDetails.ProductName,
                ProductPrice = saleDetails.ProductPrice,
                Stock = saleDetails.Stock,
                TotalAmount = saleDetails.TotalAmount
            };
        }

        public static List<SaleDetailsDto> CreateList(IEnumerable<SaleDetails> saleDetails)
        {
            return saleDetails.Select(sd => Create(sd)).ToList();
        }
    }
}

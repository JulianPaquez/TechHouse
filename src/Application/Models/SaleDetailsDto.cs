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
        public int SaleId { get; set; } // Agregado SaleId
        public int ProductId { get; set; } // Agregado ProductId 
        public Sale Sale {get; set;}
         public Product Product { get; set; } 

        public static SaleDetailsDto Create(SaleDetails saleDetails)
        {
            return new SaleDetailsDto
            {
                Id = saleDetails.Id,
                SaleId = saleDetails.SaleId,
                ProductId = saleDetails.ProductId,
                 Sale = saleDetails.Sale,
                Product = saleDetails.Product
            };
        }

        public static List<SaleDetailsDto> CreateList(IEnumerable<SaleDetails> saleDetails)
        {
            return saleDetails.Select(sd => Create(sd)).ToList();
        }
    }
}

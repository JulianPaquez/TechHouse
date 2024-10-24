using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    public class SaleDetails
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public int SaleId { get; set; }
        [ForeignKey("SaleId")]
        public Sale Sale { get; set; }

        [Required]
        public int ProductId { get; set; }
        [ForeignKey("ProductId")]
        public Product Product { get; set; }

        [Required]
        public int Stock { get; set; } // Cantidad vendida de este producto

        // Opcional: puedes incluir el stock si es necesario
        // public int StockAtSaleTime { get; set; } // Stock en el momento de la venta

        public SaleDetails() { }

        public SaleDetails(int saleId, int productId)
        {
            SaleId = saleId;
            ProductId = productId;
        }
    }
}

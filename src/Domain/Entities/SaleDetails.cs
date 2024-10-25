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

        // Información adicional del producto
        [Required]
        public string ProductName { get; set; }
        [Required]
        public decimal ProductPrice { get; set; }
        
        // Monto total calculado para este producto en esta venta
        [Required]
        public decimal TotalAmount { get; set; }

        public SaleDetails() { }

        public SaleDetails(int saleId, int productId, string productName, decimal productPrice, int stock)
        {
            SaleId = saleId;
            ProductId = productId;
            ProductName = productName;
            ProductPrice = productPrice;
            Stock = stock;
            TotalAmount = productPrice * stock; // Calcular el monto total en el momento de la creación
        }
    }
}

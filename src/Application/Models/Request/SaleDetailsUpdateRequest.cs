using System.ComponentModel.DataAnnotations;

namespace Application.Models.Request
{
    public class SaleDetailsUpdateRequest
    {
        [Required]
        public int ProductId { get; set; }

        [Required]
        public int SaleId { get; set; }

        // Agregada la propiedad Stock
        [Required]
        public int Stock { get; set; } // Cantidad vendida del producto
    }
}

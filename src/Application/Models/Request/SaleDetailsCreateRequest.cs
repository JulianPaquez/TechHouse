using Domain.Entities;

namespace Application.Models.Request
{
    public class SaleDetailsCreateRequest
    {
        public int ProductId { get; set; } // Cambiado a ProductId
        public int SaleId { get; set; } // Cambiado a SaleId
    }
}

using Domain.Entities;

namespace Application.Models.Request
{
    public class SaleDetailsUpdateRequest
    {
        public int SaleId { get; set; } // Mantenido
        public int ProductId { get; set; } // Agregado ProductId
    }
}

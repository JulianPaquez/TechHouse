using Domain.Entities;

namespace Application.Models.Request
{
    public class SaleDetailsCreateRequest
    {
        public int ProductId { get; set; } 
        public int SaleId { get; set; } 
        public int Stock {get; set;}
    }
}

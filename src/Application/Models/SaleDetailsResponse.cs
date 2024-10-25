using Domain.Entities;

namespace Application.Models
{
    public class SaleDetailsResponse
    {
        public Product Product { get; set; }
        public Sale Sale { get; set; }
    }
}
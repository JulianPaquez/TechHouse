using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Cryptography.X509Certificates;

namespace Domain.Entities
{
    public class Sale
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public DateTime DateTime { get; set; }
        public decimal TotalSaleAmount { get; set; } = 0;
        public string ProductSale { get; set; }  // Nueva propiedad para los nombres de productos
        public int ProductQuantity {get; set;} 

        [Required]
        public ICollection<SaleDetails>? SaleDetails { get; set; } = new List<SaleDetails>();

        public Sale() { }  
        
        public Sale(DateTime dateTime, decimal totalSaleAmount, string productSale, int productQuantity) // Constructor actualizado
        {
            DateTime = dateTime;
            TotalSaleAmount = totalSaleAmount;
            ProductSale = productSale;
            ProductQuantity = productQuantity;
        }
    }
}

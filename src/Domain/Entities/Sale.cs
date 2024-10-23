using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    public class Sale
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public DateTime DateTime { get; set; }
        public decimal TotalSaleAmount { get; set; }
        public string ProductSale { get; set; }
        public decimal Amount { get; set; }

        [Required]
        public ICollection<SaleDetails>? SaleDetails { get; set; }

        public Sale() { }  
        
        public Sale(DateTime dateTime, decimal totalSaleAmount, string productSale, decimal amount, ICollection<SaleDetails> saleDetails)
        {
            DateTime = dateTime;
            TotalSaleAmount = totalSaleAmount;
            ProductSale = productSale;
            Amount = amount;
            SaleDetails = saleDetails; 
        }

        public void AddSaleDetails(ICollection<SaleDetails> saleDetails)
        {
            SaleDetails = saleDetails;
        }

    }
}

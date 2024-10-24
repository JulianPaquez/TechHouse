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
        public decimal TotalSaleAmount { get; set; } = 0;

        [Required]
        public ICollection<SaleDetails>? SaleDetails { get; set; } = new List<SaleDetails>();

        public Sale() { }  
        
        public Sale(DateTime dateTime, decimal totalSaleAmount) //ICollection<SaleDetails> saleDetails)
        {
            DateTime = dateTime;
            TotalSaleAmount = totalSaleAmount;
            // SaleDetails = saleDetails;
        }
    }
}

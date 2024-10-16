using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Sale
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public DateTime DateTime { get; set; }
        public int TotalSaleAmount { get; set; }
        public string ProductSale { get; set; }
        public int Amount { get; set; }

        public Sale() { }

        public Sale(DateTime  dateTime, int totalSaleAmount, string productSale, int amount) 
        {
            DateTime = dateTime;
            TotalSaleAmount = totalSaleAmount;
            ProductSale = productSale;
            Amount = amount;
        }
    }

}

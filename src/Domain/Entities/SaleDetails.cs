﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    public class SaleDetails
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public int SaleId { get; set; } // Agregado SaleId
        [ForeignKey("SaleId")]
        public Sale Sale { get; set; }

        [Required]
        public int ProductId { get; set; } // Agregado ProductId
        [ForeignKey("ProductId")]
        public Product Product { get; set; }

        public SaleDetails() { }

        public SaleDetails(int saleId, int productId)
        {
            SaleId = saleId;
            ProductId = productId;
        }
    }
}
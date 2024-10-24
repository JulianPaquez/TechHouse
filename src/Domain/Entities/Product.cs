using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities;

public class Product
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id {get;set;}
    public string Name {get;set;}
    public int Stock {get;set;} = 0;
    public decimal Price {get;set;}
    public ICollection<SaleDetails>? SaleDetails {get; set;} = new List<SaleDetails>();

    public Product(){}

    public Product(string name, int stock,decimal price)
    {
        Name = name;
        Stock = stock;
        Price = price;
    }
}

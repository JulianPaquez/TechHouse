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
    public int QuantityStock {get;set;}
    public float Price {get;set;}

    public Product(){}

    public Product(string name, int quantity, float price)
    {
        Name = name;
        QuantityStock = quantity;
        Price = price;
    }
}

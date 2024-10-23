using System;
using Domain.Entities;

namespace Application.Models;

public class ProductDto
{
    public int Id {get;set;}
    public string Name {get;set;}
    public int QuantityStock {get;set;}
    public float Price {get;set;}

    public static ProductDto Create(Product product)
    {
        return new ProductDto
        {
            Id = product.Id,
            Name = product.Name,
            QuantityStock = product.QuantityStock,
            Price = product.Price,
        };
    }

    public static List<ProductDto> CreateList(IEnumerable<Product> products)
    {
         if (products == null || !products.Any())
        {
            return null;
            //corregir
        }

        return products.Select(p => new ProductDto
        {
            Id = p.Id,
            Name = p.Name,
            QuantityStock = p.QuantityStock,
            Price = p.Price,
            
        }).ToList();
    }
       /*  List<ProductDto> listDto = new List<ProductDto>();
        {
            foreach (var product in products)
            {
                listDto.Add(Create(product));
            }
            
            return listDto;
        } */
} 


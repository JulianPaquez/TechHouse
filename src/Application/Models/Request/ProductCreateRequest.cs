using System;

namespace Application.Models.Request;

public class ProductCreateRequest
{
    public string ? Name {get;set;}
    public int Stock{get;set;}
    public decimal Price{get;set;}
}

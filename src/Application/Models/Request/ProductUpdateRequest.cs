using System;

namespace Application.Models.Request;

public class ProductUpdateRequest
{
    public string Name {get;set;} = string.Empty;
    public int Stock{get;set;}
    public decimal Price{get;set;}
}

using System;

namespace Application.Models.Request;

public class ProductCreateRequest
{
    public string Name {get;set;}
    public int QuantityStock{get;set;}
    public float Price{get;set;}
}

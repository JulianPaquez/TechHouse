using System;

namespace Application.Models.Request;

public class ProductUpdateRequest
{
    public string Name {get;set;}
    public int QuantityStock{get;set;}
    public float Price{get;set;}
}

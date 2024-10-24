using System;
using Application.Interfaces;
using Application.Models;
using Application.Models.Request;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers;

[Route("api/[controller]")]
[ApiController]

public class ProductController : ControllerBase
{
    private readonly IProductService _productService;
    public ProductController(IProductService productService)
    {
        _productService = productService;
    }

    [HttpGet]
    public ActionResult<List<ProductDto>> GetAll()
    {
        return _productService.GetAll();
    }

    [HttpGet("{id}")]
    
    public ActionResult<ProductDto> GetById(int id)
    {
        try
        {
            return _productService.GetById(id);
        }
        catch (System.Exception)
        {
            
             return StatusCode(500, "Product not founded");
        }
    }

    [HttpPost]
    public IActionResult Create([FromBody] ProductCreateRequest request)
    {
       try
       {
            _productService.Create(request);
            return Ok();
       }
       catch (System.Exception)
       {
        
           return StatusCode(500, "Product not created");
       }
    }

    [HttpPut("{id}")]

    public IActionResult Update(int id, ProductUpdateRequest request)
    {
        try
        {
            _productService.Update(id,request);
            return Ok();
        }
        catch (System.Exception)
        {
            
            return StatusCode(500, "Product not founded");
        }
    }

    [HttpDelete]
    public IActionResult Delete(int id)
    {
        try
        {
            _productService.Delete(id);
            return Ok();
        }
        catch (System.Exception)
        {
            
            return StatusCode(500, "Product not founded");
        }
    }


}

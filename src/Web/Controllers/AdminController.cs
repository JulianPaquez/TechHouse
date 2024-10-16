using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Domain.Entities;
using Application;
using Appication.Interfaces;
using Application.Request;
using Application.Models;


namespace Web.Controllers;


[Route("api/[controller]")]
[ApiController]

public class AdminController : ControllerBase
{
    private readonly IAdminService _adminService;
    public AdminController(IAdminService adminService)
    {
        _adminService = adminService;
    }


    [HttpGet]

    public ActionResult<List<AdminDto>> GetAll()
    {
        return _adminService.GetAll();
    }

    [HttpGet("{id}")]

    public ActionResult<AdminDto> GetByid(int id)
    {
        try
        {
            return _adminService.GetById(id);
        }
        catch (System.Exception)
        {

            return BadRequest();
        }

    }

    [HttpGet("clients")]
    public ActionResult<List<ClientDto>> GetAllClients()
    {
        try
    {
        var result = _adminService.GetAllClients();
        return Ok(result);
    }
    catch (Exception ex)
    {
        // Log error details
        Console.WriteLine("Error retrieving products: " + ex.Message);
        return BadRequest(new { error = ex.Message, stackTrace = ex.StackTrace });
    }
    }

    // Endpoint para obtener todos los productos
    [HttpGet("products")]
    public ActionResult<List<ProductDto>> GetAllProducts()
    {
         try
    {
        var result = _adminService.GetAllProducts();
        return Ok(result);
    }
    catch (Exception ex)
    {
        // Log error details
        Console.WriteLine("Error retrieving products: " + ex.Message);
        return BadRequest(new { error = ex.Message, stackTrace = ex.StackTrace });
    }
    }
    [HttpPost]

    public IActionResult Create(AdminCreateRequest request)
    {
        return Ok(_adminService.Create(request));
    }
    [HttpPut("{id}")]
    public IActionResult Update(int id, AdminUpdateRequest request)
    {
        try
        {
            _adminService.Update(id, request);
            return Ok();
        }
        catch (System.Exception)
        {
            return BadRequest();
        }
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        try
        {
            _adminService.Delete(id);
            return Ok();
        }
        catch (System.Exception)
        {

            return NotFound();
        }


    }
}

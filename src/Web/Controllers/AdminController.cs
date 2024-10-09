using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Domain.Entities;
using Application;
using Appication.Interfaces;
using Application.Request;


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
        return _adminService.GetById(id);
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
        _adminService.Delete(id);
        return Ok();
    }
}

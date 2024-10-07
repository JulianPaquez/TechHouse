using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Domain.Entities;
using Application;
using Appication.Interfaces;
using Application.Request;


namespace Web.Controllers;


[Route("api/[controller]")]
[ApiController]

public class SysAdminController : ControllerBase
{
    private readonly ISysAdminService _sysAdminService;
    public SysAdminController(ISysAdminService sysAdminService)
    {
        _sysAdminService = sysAdminService;
    }

    [HttpGet]

    public ActionResult<List<SysAdminDto>> GetAll()
    {
      return _sysAdminService.GetAll();
    }

    [HttpGet("{id}")]

    public ActionResult<SysAdminDto> GetByid(int id) 
    {
        return _sysAdminService.GetById(id);
    }

    [HttpPost]

    public IActionResult Create( SysAdminCreateRequest request )
    {
        return Ok(_sysAdminService.Create(request));
    }

    [HttpPut("{id}")]
    public IActionResult Update(int id, SysAdminUpdateRequest request ) 
    {
         try
        {
            _sysAdminService.Update(id,request);
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
        _sysAdminService.Delete(id);
        return Ok();
    }
}
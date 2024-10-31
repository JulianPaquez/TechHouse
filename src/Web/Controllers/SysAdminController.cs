using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Domain.Entities;
using Application;
using Appication.Interfaces;
using Application.Request;
using Microsoft.AspNetCore.Authorization;


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
    [Authorize(Roles = "SysAdmin")]

    public ActionResult<List<SysAdminDto>> GetAll()
    {
        return _sysAdminService.GetAll();
    }

    [HttpGet("{id}")]
    [Authorize(Roles = "SysAdmin")]


    public ActionResult<SysAdminDto> GetByid([FromRoute] int id)
    {
        try
        {
            return _sysAdminService.GetById(id);
        }
        catch (System.Exception)
        {

            return BadRequest();
        }
    }

    [HttpPost]
    [Authorize(Roles = "SysAdmin")]


    public IActionResult Create([FromBody] SysAdminCreateRequest request)
    {
        return Ok(_sysAdminService.Create(request));
    }

    [HttpPut("{id}")]
    [Authorize(Roles = "SysAdmin")]


    public IActionResult Update([FromRoute] int id, [FromBody] SysAdminUpdateRequest request)
    {
        try
        {
            _sysAdminService.Update(id, request);
            return Ok();
        }
        catch (System.Exception)
        {
            return BadRequest();
        }
    }

    [HttpDelete("{id}")]
    [Authorize(Roles = "SysAdmin")]

    public IActionResult Delete([FromRoute] int id)
    {
        try
        {
            _sysAdminService.Delete(id);
            return Ok();
        }
        catch (System.Exception)
        {

            return NotFound();
        }
    }
}
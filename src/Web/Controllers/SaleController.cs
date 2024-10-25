using Application.Interfaces;
using Application.Models;
using Application.Models.Request;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SaleController : ControllerBase
    {
        private readonly ISaleServices _saleServices;
        public SaleController(ISaleServices saleServices)
        {
            _saleServices = saleServices;
        }
        [HttpGet]
        [Authorize(Roles = "SysAdmin,Admin,Client")]

        public ActionResult<List<SaleDto>> GetAll()
        {
            return _saleServices.GetAll();
        }
        [HttpGet("{id}")]
        [Authorize(Roles = "SysAdmin,Admin,Client")]
        public ActionResult<SaleDto> GetById(int id)
        {
            try
            {
                return _saleServices.GetById(id);
            }
            catch (System.Exception)
            {
                return StatusCode(500, "No se encontro una venta con ese ID");
            }
        }
        [HttpPost]
        [Authorize(Roles = "SysAdmin,Admin,Client")]
        public IActionResult Create(SaleCreateRequest request)
        {

            _saleServices.Create(request);
            return Ok("Se creo la venta con exito");
        }
        [HttpPut("{id}")]
        [Authorize(Roles = "SysAdmin,Admin,Client")]
        public IActionResult Update(int id, [FromBody] SaleUpdateRequest request)
        {
            try
            {
                _saleServices.Update(id, request);
                return Ok();
            }
            catch (System.Exception)
            {
                return StatusCode(500, "No se encontro una venta con ese ID");
            }
        }
        [HttpDelete("{id}")]
        [Authorize(Roles = "SysAdmin,Admin,Client")]
        public IActionResult Delete(int id)
        {
            try
            {
                _saleServices.Delete(id);
                return Ok();
            }
            catch (System.Exception)
            {
                return StatusCode(500, "No se encontro una venta con ese ID");
            }
        }

    }
}

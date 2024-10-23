using Application.Interfaces;
using Application.Models;
using Application.Models.Request;
using Application.Services;
using Microsoft.AspNetCore.Mvc;
using Web.Controllers;

namespace TechHouse.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SaleDetailsController : ControllerBase
    {
        private readonly ISaleDetailsService _saleDetailsService;
        public SaleDetailsController(ISaleDetailsService saleDetailsService)
        {
            _saleDetailsService = saleDetailsService;
        }
        [HttpGet]
        public ActionResult<List<SaleDetailsDto>> GetAll() 
        {
            return _saleDetailsService.GetAll();
        }
        [HttpPost]
        public  IActionResult Create([FromBody] SaleDetailsCreateRequest request)
        {
            try
            {
                _saleDetailsService.Create(request);
                return Ok();
            }
            catch (System.Exception)
            {
                return StatusCode(500);
            }
        }
    }
}

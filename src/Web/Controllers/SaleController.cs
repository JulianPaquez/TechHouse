﻿using Application.Interfaces;
using Application.Models;
using Application.Models.Request;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SaleController : ControllerBase
    {
        private readonly ISaleServices _saleServices;
        public SaleController(ISaleServices saleServices)
        {
            _saleServices = saleServices;
        }
        [HttpGet]
        public ActionResult<List<SaleDto>> GetAll()
        {
            return _saleServices.GetAll();
        }
        [HttpGet("{id}")]
        public ActionResult<SaleDto> GetById(int id)
        {
            try
            {
                return _saleServices.GetById(id);
            }
            catch (System.Exception)
            {
                return StatusCode(500,"No se encontro una venta con ese ID");
            }
        }
        [HttpPost]
        public IActionResult Create(SaleCreateRequest request)
        {
            return Ok(_saleServices.Create(request));     
        }
        [HttpPut("{id}")]
        public IActionResult Update(int id,[FromBody]SaleUpdateRequest request)
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

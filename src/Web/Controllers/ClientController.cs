using Application.Models;
using Application.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace Web.Controllers
{

    [Route("api/[controller]")]
    [ApiController]


    public class ClientController : ControllerBase
    {

        private readonly IClientService _service;

        public ClientController(IClientService service)
        {
            _service = service;
        }

        [HttpPost]
        //[Authorize(Roles = "SysAdmin,Admin")]

        public IActionResult Create([FromBody] ClientCreateRequest request)
        {
            return Ok(_service.Create(request));
        }

        [HttpGet]
        //[Authorize(Roles = "SysAdmin,Admin")]
        public ActionResult<List<ClientDto>> GetAll()
        {
            return _service.GetAll();
        }

        [HttpGet("{id}")]
        [Authorize(Roles = "SysAdmin,Admin")]
        public ActionResult<ClientDto> GetById([FromRoute] int id)
        {
            var client = _service.GetById(id);
            if (client == null)
            {
                return NotFound();
            }
            return Ok(client);
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "SysAdmin,Admin, Client")]

        public IActionResult Update([FromRoute] int id, [FromBody] ClientUpdateRequest request)
        {

            var result = _service.Update(id, request);

            if (!result)
            {
                return NotFound(new { message = $"Client with Id {id} not found." });
            }

            return Ok(new { message = "Client updated successfully." });
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "SysAdmin,Admin")]
        public IActionResult Delete([FromRoute] int id)
        {
            try
            {
                _service.Delete(id);
                return Ok();
            }
            catch (Exception)
            {
                return NotFound();
            }
        }
    }
};
using Application.Models;
using Application.Services;
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
        public IActionResult Create(ClientCreateRequest request)
        {
            return Ok(_service.Create(request));
        }

        [HttpGet]
        public ActionResult<List<ClientDto>> GetAll()
        {
            return _service.GetAll();
        }

        [HttpGet("{id}")]
        public ActionResult<ClientDto> GetById(int id)
        {
            var client = _service.GetById(id);
            if (client == null)
            {
                return NotFound();
            }
            return Ok(client);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, ClientUpdateRequest request)
        {

            var result = _service.Update(id, request);

            if (!result)
            {
                return NotFound(new { message = $"Client with Id {id} not found." });
            }

            return Ok(new { message = "Client updated successfully." });
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
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
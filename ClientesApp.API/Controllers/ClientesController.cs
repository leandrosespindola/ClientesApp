using ClientesApp.Application.DTO;
using ClientesApp.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ClientesApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientesController : ControllerBase
    {
        private readonly IClienteAppService _clienteAppService;

        public ClientesController(IClienteAppService clienteAppService)
        {
            _clienteAppService = clienteAppService;
        }

        [HttpPost]
        [ProducesResponseType(typeof(ClienteResponseDto), 201)]
        public async Task<IActionResult> Post([FromBody] ClienteRequestDto request)
        {
            return StatusCode(201, await _clienteAppService.AddAsync(request));
        }

        [HttpPut("{id}")]
        //[Route("editar")]
        [ProducesResponseType(typeof(ClienteResponseDto), 200)]
        public async Task<IActionResult> Put(Guid id, [FromBody] ClienteRequestDto request)
        {
            return StatusCode(200, await _clienteAppService.UpdateAsync(id, request));
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(ClienteResponseDto), 200)]
        public async Task<IActionResult> Delete(Guid id)
        {
            return StatusCode(200, await _clienteAppService.DeleteAsync(id));
        }

        [HttpGet]
        [ProducesResponseType(typeof(ClienteResponseDto), 200)]
        public async Task<IActionResult> Get([FromQuery] string nome)
        {
            return StatusCode(200, await _clienteAppService.GetManyAsync(nome));
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(ClienteResponseDto), 200)]
        public async Task<IActionResult> Get(Guid id)
        {
            return StatusCode(200, await _clienteAppService.GetByIdAsync(id));
        }
    }
}

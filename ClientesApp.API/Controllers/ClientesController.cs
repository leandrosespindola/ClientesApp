using ClientesApp.Application.Dtos;
using ClientesApp.Application.Interfaces.Applications;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ClientesApp.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ClientesController : ControllerBase
    {
        private readonly IClienteAppService _clienteAppService;

        public ClientesController(IClienteAppService clienteAppService)
        {
            _clienteAppService = clienteAppService;
        }

        //[AllowAnonymous]
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

        [HttpGet("logs/{id}")] // /api/clientes/logs/1?pageIndex=1&pagesize=10
        [ProducesResponseType(typeof(LogClienteResponseDto), 200)]
        public async Task<IActionResult> GetLogs(Guid id, [FromQuery] LogClienteRequestDto request)
        {
            return StatusCode(200, await _clienteAppService.GetLogs(id, request));
        }

    }
}

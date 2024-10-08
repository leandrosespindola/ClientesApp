using ClientesApp.Application.Dtos;

namespace ClientesApp.Application.Interfaces.Applications
{
    public interface IClienteAppService : IDisposable
    {
        Task<ClienteResponseDto> AddAsync(ClienteRequestDto request);
        Task<ClienteResponseDto> UpdateAsync(Guid id, ClienteRequestDto request);
        Task<ClienteResponseDto> DeleteAsync(Guid id);
        Task<List<ClienteResponseDto>> GetManyAsync(string nome);
        Task<ClienteResponseDto?> GetByIdAsync(Guid id);
    }
}

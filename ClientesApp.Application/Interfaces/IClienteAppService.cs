using ClientesApp.Application.DTO;

namespace ClientesApp.Application.Interfaces
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

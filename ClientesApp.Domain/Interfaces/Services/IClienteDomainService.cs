using ClientesApp.Domain.Entities;

namespace ClientesApp.Domain.Interfaces.Services
{
    public interface IClienteDomainService : IDisposable
    {
        Task<Cliente> AddAsync(Cliente cliente);
        Task<Cliente> UpdateAsync(Cliente cliente);
        Task<Cliente> DeleteAsync(Guid id);
        Task<List<Cliente>> GetManyAsync(string nome);
        Task<Cliente?> GetByIdAsync(Guid id);
    }
}

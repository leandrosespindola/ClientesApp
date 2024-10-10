using ClientesApp.Application.Models;

namespace ClientesApp.Application.Interfaces.Logs
{
    public interface ILogClienteDataStore
    {
        Task AddAsync(LogClienteModel model);
        Task<List<LogClienteModel>> GetAsync(Guid clienteId, int pageNumber, int pageSize);
        Task<int> GetTotalCountAsync(Guid clienteId);
    }
}

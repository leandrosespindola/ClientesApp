using ClientesApp.Application.Interfaces.Logs;
using ClientesApp.Application.Models;
using ClientesApp.Infra.Data.MongoDB.Contexts;
using MongoDB.Driver;

namespace ClientesApp.Infra.Data.MongoDB.Storages
{
    public class LogClienteDataStore : ILogClienteDataStore
    {
        private readonly MongoDBContext _mongoDBContext;

        public LogClienteDataStore(MongoDBContext mongoDBContext)
        {
            _mongoDBContext = mongoDBContext;
        }

        public async Task AddAsync(LogClienteModel model)
        {
            await _mongoDBContext.LogClientes.InsertOneAsync(model);
        }

        public async Task<List<LogClienteModel>> GetAsync(Guid clienteId, int pageNumber, int pageSize)
        {
            var filter = Builders<LogClienteModel>.Filter.Eq(log => log.ClienteId, clienteId);

            var result = await _mongoDBContext.LogClientes
                .Find(filter)
                .Skip((pageNumber -1) * pageSize)
                .Limit(pageSize)
                .SortByDescending(log => log.DataOperacao)
                .ToListAsync();

            return result;
        }

        public async Task<int> GetTotalCountAsync(Guid clienteId)
        {
            var filter = Builders<LogClienteModel>.Filter.Eq(log => log.ClienteId, clienteId);

            return (int) await _mongoDBContext.LogClientes.CountDocumentsAsync(filter);
        }
    }
}

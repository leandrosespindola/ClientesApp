﻿using ClientesApp.Application.Interfaces.Logs;
using ClientesApp.Application.Models;
using ClientesApp.Infra.Data.MongoDB.Contexts;

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
    }
}

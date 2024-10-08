using ClientesApp.Application.Models;
using ClientesApp.Infra.Data.MongoDB.Settings;
using MongoDB.Driver;

namespace ClientesApp.Infra.Data.MongoDB.Contexts
{
    public class MongoDBContext 
    {
        private readonly MongoDBSettings _mongoDBSettings;
        private IMongoDatabase _mongoDatabase;

        public MongoDBContext(MongoDBSettings mongoDBSettings)
        {
            _mongoDBSettings = mongoDBSettings;

            #region Conexão com o banco de dados

            var settings = MongoClientSettings.FromUrl(new MongoUrl(_mongoDBSettings.Url));
            var client = new MongoClient(settings);

            _mongoDatabase = client.GetDatabase(_mongoDBSettings.Database);

            #endregion
        }

        public IMongoCollection<LogClienteModel> LogClientes
            => _mongoDatabase.GetCollection<LogClienteModel>("LogClientes");

    }
}

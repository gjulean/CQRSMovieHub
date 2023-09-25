using CQRSMovieHub.Queries.DataAccess.Implementations.Options;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Driver;

namespace CQRSMovieHub.Queries.DataAccess.Implementations.Providers
{
    public abstract class MongoDbProvider<T>
    {
        private MongoClient _client { get; set; }
        private IMongoDatabase _mongoDatabase { get; set; }
        internal virtual string Table { get; set; }

        public MongoDbProvider(IServiceProvider services)
        {
            var configuration = services.GetRequiredService<IConfiguration>();
            var mongoDbSettings = configuration.GetMongoDbConnectionOptions();
            _client = new MongoClient(mongoDbSettings.ConnectionString);
            _mongoDatabase = _client.GetDatabase(mongoDbSettings.DatabaseName);
        }

        public IMongoCollection<T> GetCollection()
        {
            return _mongoDatabase.GetCollection<T>(Table);
        }
    }
}

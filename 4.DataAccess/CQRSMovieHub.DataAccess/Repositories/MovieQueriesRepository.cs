using CQRSMovieHub.Domain.Entities.Entities;
using CQRSMovieHub.Queries.DataAccess.Contracts;
using CQRSMovieHub.Queries.DataAccess.Implementations.Providers;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;

namespace CQRSMovieHub.Queries.DataAccess.Implementations.Repositories
{
    public class MovieQueriesRepository : MongoDbProvider<Movie>, IMovieQueriesRepository
    {
        internal override string Table { get; set; } = "Movies";

        public MovieQueriesRepository(IServiceProvider serviceProvider): base(serviceProvider)
        {
        }

        public Task<Movie> GetMovieById(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Movie>> GetMovies()
        {
            var collection = GetCollection();

            var test = await collection.CountAsync(_ => true);

            var entities = await collection.Find(_ => true).ToListAsync();

            return entities;
        }        
    }
}

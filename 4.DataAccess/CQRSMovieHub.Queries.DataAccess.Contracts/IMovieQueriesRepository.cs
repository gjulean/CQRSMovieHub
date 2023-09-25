using CQRSMovieHub.Domain.Entities.Entities;

namespace CQRSMovieHub.Queries.DataAccess.Contracts;

public interface IMovieQueriesRepository
{
    Task<IEnumerable<Movie>> GetMovies();

    Task<Movie> GetMovieById(int id);
}

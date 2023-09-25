using CQRSMovieHub.Domain.Entities.Entities;
using CQRSMovieHub.Domain.Entities.ModelsIn;

namespace CQRSMovieHub.Services.Contracts
{
    public interface IMovieService
    {
        Task<IEnumerable<Movie>> GetMoviesAsync();

        Task<Movie> GetMovieByIdAsync(int id);

        Task<Movie> AddAsync(MovieModelIn movie);
    }
}

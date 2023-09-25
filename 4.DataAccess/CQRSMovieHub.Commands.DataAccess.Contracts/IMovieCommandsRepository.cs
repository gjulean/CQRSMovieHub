using CQRSMovieHub.Domain.Entities.Entities;

namespace CQRSMovieHub.Commands.DataAccess.Contracts
{
    public interface IMovieCommandsRepository
    {
        Task<Movie> AddAsync(Movie movie);
    }
}

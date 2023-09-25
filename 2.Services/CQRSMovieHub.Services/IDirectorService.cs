using CQRSMovieHub.Domain.Entities.Entities;

namespace CQRSMovieHub.Services.Contracts;

public interface IDirectorService
{
    Task<Director> AddAsync(Director director);
}

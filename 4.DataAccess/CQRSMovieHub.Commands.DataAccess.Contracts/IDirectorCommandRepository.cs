using CQRSMovieHub.Domain.Entities.Entities;

namespace CQRSMovieHub.Commands.DataAccess.Contracts;

public interface IDirectorCommandRepository
{
    Task<Director> AddAsync(Director director);
}

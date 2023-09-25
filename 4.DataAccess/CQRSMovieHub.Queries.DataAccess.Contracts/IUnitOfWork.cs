using CQRSMovieHub.Domain.Entities.Entities;

namespace CQRSMovieHub.Queries.DataAccess.Contracts;

public interface IUnitOfWork
{
    public IRepository<Director> Directors { get; }
    public IRepository<Movie> Movies { get; }
    public void Save();
}

using CQRSMovieHub.Commands.DataAccess.Contracts;
using CQRSMovieHub.Domain.Entities.Entities;
using CQRSMovieHub.Queries.DataAccess.Implementations.Context;
using Microsoft.Extensions.DependencyInjection;

namespace CQRSMovieHub.Command.DataAccess.Implementations;

public class DirectorCommandRepository : IDirectorCommandRepository
{
    private CQRSMovieHubContext _context { get; set; }

    public DirectorCommandRepository(IServiceProvider services)
    {
        _context = services.GetRequiredService<CQRSMovieHubContext>();
    }

    public async Task<Director> AddAsync(Director director)
    {
        var result = await _context.Director.AddAsync(director);

        return result.Entity;
    }
}

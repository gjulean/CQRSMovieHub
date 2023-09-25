using CQRSMovieHub.Commands.DataAccess.Contracts;
using CQRSMovieHub.Domain.Entities.Entities;
using CQRSMovieHub.Queries.DataAccess.Implementations.Context;
using Microsoft.Extensions.DependencyInjection;

namespace CQRSMovieHub.Command.DataAccess.Implementations;

public class MovieCommandsRepository : IMovieCommandsRepository
{
    private CQRSMovieHubContext _context { get; set; }

    public MovieCommandsRepository(IServiceProvider services)
    {
        _context = services.GetRequiredService<CQRSMovieHubContext>();
    }

    public async Task<Movie> AddAsync(Movie movie)
    {
        var result = await _context.AddAsync(movie);

        return result.Entity;
    }
}

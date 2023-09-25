using AutoMapper;
using CQRSMovieHub.Commands.DataAccess.Contracts;
using CQRSMovieHub.Domain.Entities.Entities;
using CQRSMovieHub.Services.Contracts;
using Microsoft.Extensions.DependencyInjection;

namespace CQRSMovieHub.Services.Implementations.Directors;

public class DirectorService : IDirectorService
{
    private readonly IMapper _mapper;
    private readonly IDirectorCommandRepository _directorCommandRepository;

    public DirectorService(IServiceProvider serviceProvider)
    {
        _mapper = serviceProvider.GetRequiredService<IMapper>();     
        _directorCommandRepository = serviceProvider.GetRequiredService<IDirectorCommandRepository>();
    }

    public async Task<Director> AddAsync(Director director)
    {
        return await _directorCommandRepository.AddAsync(director);
    }
}

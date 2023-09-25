using AutoMapper;
using CQRSMovieHub.Commands.DataAccess.Contracts;
using CQRSMovieHub.Domain.Entities.Entities;
using CQRSMovieHub.Domain.Entities.ModelsIn;
using CQRSMovieHub.Queries.DataAccess.Contracts;
using CQRSMovieHub.Services.Contracts;
using Microsoft.Extensions.DependencyInjection;

namespace CQRSMovieHub.Services.Implementations.Movies
{
    public class MovieService : IMovieService
    {
        private readonly IMovieQueriesRepository _movieQueriesRepository;
        private readonly IMovieCommandsRepository _movieCommandsRepository;
        private readonly IMapper _mapper;

        public MovieService(IServiceProvider serviceProvider)
        {
            _movieQueriesRepository = serviceProvider.GetRequiredService<IMovieQueriesRepository>();
            _movieCommandsRepository = serviceProvider.GetRequiredService<IMovieCommandsRepository>();
            _mapper = serviceProvider.GetRequiredService<IMapper>();
        }

        public async Task<Movie> GetMovieByIdAsync(int id)
        {
            return await _movieQueriesRepository.GetMovieById(id);
        }

        public async Task<IEnumerable<Movie>> GetMoviesAsync()
        {
            return await _movieQueriesRepository.GetMovies();
        }

        public async Task<Movie> AddAsync(MovieModelIn movie)
        {
            var entity = _mapper.Map<Movie>(movie);
            return await _movieCommandsRepository.AddAsync(entity);
        }
    }
}

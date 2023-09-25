using CQRSMovieHub.Domain.Entities.Entities;
using CQRSMovieHub.Domain.Entities.In;
using CQRSMovieHub.Services.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace CQRSMovieHub.Controllers
{
    [ApiController]
    [Route("api/movies")]
    public class MovieController : Controller
    {
        private readonly IMovieService _movieService;

        public MovieController(IServiceProvider serviceProvider)
        {
            _movieService = serviceProvider.GetRequiredService<IMovieService>();                
        }

        [HttpPost]
        public async Task<IActionResult> AddMovieAsync([FromBody] MovieModelIn movie)
        {
            var result = await _movieService.AddAsync(movie);
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetMoviesAsync()
        {
            var result = await _movieService.GetMoviesAsync();
            return Ok(result);
        }

    }
}

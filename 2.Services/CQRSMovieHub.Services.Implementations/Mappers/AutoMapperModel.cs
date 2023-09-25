using AutoMapper;
using CQRSMovieHub.Domain.Entities.Entities;
using CQRSMovieHub.Domain.Entities.In;

namespace CQRSMovieHub.Services.Implementations.Mappers;

public class AutoMapperModel : Profile
{
    public AutoMapperModel()
    {
        CreateMap<MovieModelIn, Movie>();
        CreateMap<DirectorModelIn, Director>();
    }
}

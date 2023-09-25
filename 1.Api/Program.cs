using CQRSMovieHub.Command.DataAccess.Implementations;
using CQRSMovieHub.Commands.DataAccess.Contracts;
using CQRSMovieHub.Queries.DataAccess.Contracts;
using CQRSMovieHub.Queries.DataAccess.Implementations.Context;
using CQRSMovieHub.Queries.DataAccess.Implementations.Repositories;
using CQRSMovieHub.Services.Contracts;
using CQRSMovieHub.Services.Implementations.Directors;
using CQRSMovieHub.Services.Implementations.Mappers;
using CQRSMovieHub.Services.Implementations.Movies;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

var services = builder.Services;
var configuration = builder.Configuration;

services.AddControllers();
services.AddEndpointsApiExplorer();
services.AddSwaggerGen();
services.AddAutoMapper(typeof(AutoMapperModel));

services.AddScoped<IMovieQueriesRepository, MovieQueriesRepository>();
services.AddScoped<IMovieCommandsRepository, MovieCommandsRepository>();
services.AddScoped<IDirectorCommandRepository, DirectorCommandRepository>();

services.AddScoped<IMovieService, MovieService>();
services.AddScoped<IDirectorService, DirectorService>();

services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "CQRSMovieHub.Api", Version = "v1" });
});

services.AddDbContext<CQRSMovieHubContext>(options =>
{
    options.UseNpgsql(configuration.GetConnectionString("CQRSMovieHubDB"));
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

if (app.Environment.IsDevelopment())
{
    // Enable Swagger UI in the development environment
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "CQRSMovieHub.Api");
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

using CQRSMovieHub.Queries.DataAccess.Implementations.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace CQRSMovieHub.Queries.DataAccess.Implementations.Design;

public class CQRSMovieHubContextDesignTimeDbContextFactory : IDesignTimeDbContextFactory<CQRSMovieHubContext>
{
    public CQRSMovieHubContextDesignTimeDbContextFactory()
    {
    }

    public CQRSMovieHubContext CreateDbContext(string[] args)
    {
        var configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .AddJsonFile($"appsettings.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT")}.json", true)
            .Build();

        string connectionString = configuration.GetConnectionString("CQRSMovieHubDB");

        var optionsBuilder = new DbContextOptionsBuilder<CQRSMovieHubContext>();
        optionsBuilder.UseNpgsql(connectionString);

        return new CQRSMovieHubContext(optionsBuilder.Options);
    }
}

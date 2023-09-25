using Microsoft.Extensions.Configuration;
using System;


namespace CQRSMovieHub.Queries.DataAccess.Implementations.Options;

public class MongoDbConnectionOptions
{
    public string ConnectionString { get; set; }

    public string DatabaseName { get; set; }
}

public static class MongoDbConnectionOptionsExtensions
{
    public static MongoDbConnectionOptions GetMongoDbConnectionOptions(this IConfiguration configuration, string settingsSectionKey = "MongoDBSettings")
    {
        if (string.IsNullOrWhiteSpace(settingsSectionKey))
            throw new ArgumentNullException(nameof(settingsSectionKey));

        var config = configuration
                .GetSection(settingsSectionKey)
                .Get<MongoDbConnectionOptions>();

        return config ?? throw new ArgumentException($"The section {settingsSectionKey} is not found in the configuracion files, please check your appsettings.json or appsettings.<enviroment>.json ");
    }
}

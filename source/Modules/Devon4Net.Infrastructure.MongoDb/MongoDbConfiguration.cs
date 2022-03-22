using Devon4Net.Infrastructure.Common.Handlers;
using Devon4Net.Infrastructure.Common.Options.MongoDb;
using Devon4Net.Infrastructure.MongoDb;
using Devon4Net.Infrastructure.MongoDb.MongoDb;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Devon4Net.Application.WebAPI.Configuration { 

public static class MongoDbConfiguration
{
    public static void SetupMongoDb(this IServiceCollection services, IConfiguration configuration)
    {
        var mongoDbOptions = services.GetTypedOptions<MongoDbOptions>(configuration, "MongoDb");
        if (mongoDbOptions == null || string.IsNullOrEmpty(mongoDbOptions?.DatabaseLocation) || !mongoDbOptions.EnableMongoDb) return;

        services.AddSingleton<IMongoDbContext, MongoDbContext>();
    }
}

}
using Devon4Net.Infrastructure.Common.Handlers;
using Devon4Net.Infrastructure.MongoDb.MongoDb;
using Devon4Net.Infrastructure.MongoDb.Options;
using Devon4Net.Infrastructure.MongoDb.Repository;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Devon4Net.Application.WebAPI.Configuration
{
    public static class MongoDbConfiguration
    {
        public static void SetupMongoDb(this IServiceCollection services, IConfiguration configuration)
        {
            var MongoDbOptions = services.GetTypedOptions<MongoDbOptions>(configuration, "MongoDb");
            if (MongoDbOptions == null || string.IsNullOrEmpty(MongoDbOptions?.DatabaseLocation) || !MongoDbOptions.EnableMongoDb) return;

            services.AddSingleton<IMongoDbContext, MongoDbContext>();
            services.AddTransient(typeof(IMongoDbRepository<>),typeof(MongoDbRepository<>));
        }
    }
}

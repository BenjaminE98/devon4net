using MongoDB.Driver;

namespace Devon4Net.Infrastructure.MongoDb
{
    public interface IMongoDbContext
    {
        IMongoDatabase Database { get; }
    }
}
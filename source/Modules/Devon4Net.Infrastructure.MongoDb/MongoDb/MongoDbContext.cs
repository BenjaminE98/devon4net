using Devon4Net.Infrastructure.Common.Common.IO;
using Devon4Net.Infrastructure.MongoDb.Options;
using MongoDB.Driver;
using Microsoft.Extensions.Options;

namespace Devon4Net.Infrastructure.MongoDb.MongoDb
{
    public class MongoDbContext : IMongoDbContext
    {
        public IMongoDatabase Database { get; }

        private IMongoClient _client { get; }

        public MongoDbContext(IOptions<MongoDbOptions> options)
        {
            _client = new MongoClient("mongodb+srv://<username>:<password>@<cluster-address>/test?w=majority");

            Database = _client.GetDatabase("USER_STRING");
        }
    }
}

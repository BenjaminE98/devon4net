using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MongoDB.Driver;

using Microsoft.Extensions.Options;

using Devon4Net.Infrastructure.Common.Common.IO;
using Devon4Net.Infrastructure.Common.Options.MongoDb;

namespace Devon4Net.Infrastructure.MongoDb.MongoDb
{
    public class MongoDbContext : IMongoDbContext
    {
        public MongoClient MongoClient { get; }

        public IMongoDatabase Database  { get; }

        public MongoDbContext(IOptions<MongoDbOptions> options)
        {
            // TODO: check if null-non-existent

            this.MongoClient = new MongoClient(options.Value.DatabaseLocation);

            var dbList = this.MongoClient.ListDatabases().ToList();

            this.Database = MongoClient.GetDatabase("Users");
        }
    }
}

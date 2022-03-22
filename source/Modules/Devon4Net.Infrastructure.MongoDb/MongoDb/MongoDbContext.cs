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
            // TODO: Fix this

            var connectionString = "mongodb://AzureDiamond:hunter2@mongo:27017/?readPreference=primary&appname=MongoDB%20Compass&directConnection=true&ssl=false";

            this.MongoClient = new MongoClient(connectionString);

            this.Database = MongoClient.GetDatabase("Users");
        }


    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MongoDB.Driver;

namespace Devon4Net.Infrastructure.MongoDb.Repository
{
    public class Repository<T> : IRepository<T>
    {
        private IMongoDatabase MongoDb { get;  }

        public Repository(IMongoDbContext mongoDbContext)
        {
            MongoDb = mongoDbContext?.Database ?? throw new ArgumentException("The database can not be null! Please check your connection-settings!");


        } 

        public IEnumerable<T> Get()
        {
            var collection = MongoDb.GetCollection<T>(typeof(T).Name);

            return collection.Find<T>(_ => true).ToList();
        }
    }
}

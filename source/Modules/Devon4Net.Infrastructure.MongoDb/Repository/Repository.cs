using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Devon4Net.Infrastructure.MongoDb.MongoDb;
using MongoDB.Bson;
using MongoDB.Driver;

namespace Devon4Net.Infrastructure.MongoDb.Repository
{
    public class Repository<T> : IRepository<T>
    {
        private IMongoDatabase MongoDb { get;  }

        private readonly IMongoCollection<T> MongoCollection;

        private readonly FilterDefinitionBuilder<T> FilterDefinitionBuilder = Builders<T>.Filter;

        public Repository(IMongoDbContext mongoDbContext)
        {
            MongoDb = mongoDbContext?.Database ?? throw new ArgumentException("The database can not be null! Please check your connection-settings!");

            MongoCollection = MongoDb.GetCollection<T>(typeof(T).Name);
        }

        // Create / Put - manifests an entity in the database
        public void Create(T entity)
        {
            MongoCollection.InsertOne(entity);
        }

        // Get - returns all entites as an enumerable (in the matching collection)
        public IEnumerable<T> Get()
        {
            return MongoCollection.Find<T>(item => true).ToList();
        }

        // Get - returns all entites as an enumerable (under the condition of matching the predicate)
        public IEnumerable<T> Get(Expression<Func<T, bool>> predicate)
        {
            return MongoCollection.Find<T>(predicate).ToList();
        }

        // Get - returns the first matching entity or a defaulted value (under the condition of matching the predicate)
        public T GetFirstOrDefault(Expression<Func<T, bool>> predicate)
        {
            return MongoCollection.Find(predicate).FirstOrDefault();
        }

        // Update - replaces a matching entity using an updated entity 
        public void Update(Expression<Func<T, bool>> predicate, T updatedEntity)
        {
            MongoCollection.ReplaceOne(predicate, updatedEntity);
        }

        // Delete - deletes multiple entites in the database (under the condition of matching the predicate)
        public void Delete(Expression<Func<T, bool>> predicate)
        {
            MongoCollection.DeleteMany(predicate);
        }



        // Experimental

        /*
        public async Task<IReadOnlyCollection<T>> GetAllAsync()
        {
            return await MongoCollection.Find(FilterDefinitionBuilder.Empty).ToListAsync();
        }

        public async Task<IReadOnlyCollection<T>> GetAsync(Expression<Func<T, bool>> predicate)
        {
            return await MongoCollection.Find<T>(predicate).ToListAsync();
        }
        */
    }
}

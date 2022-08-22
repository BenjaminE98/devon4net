using Devon4Net.Infrastructure.MongoDb.MongoDb;
using Devon4Net.Infrastructure.Logger.Logging;
using MongoDB.Bson;
using MongoDB.Driver;
using System.Linq.Expressions;

namespace Devon4Net.Infrastructure.MongoDb.Repository
{
    public class MongoDbRepository<T> : IMongoDbRepository<T> where T : class
    {
        public IMongoDatabase MongoDb { get; }
        private IMongoCollection<T> MongoCollection { get; }

        public MongoDbRepository(IMongoDbContext MongoDbContext)
        {
            MongoDb = MongoDbContext?.Database ?? throw new ArgumentException("The context can not be null. Please check your DI container configuration and check if the container has declared the instance of the context");
            MongoCollection = MongoDb.GetCollection<T>(typeof(T).Name);
        }

        public BsonValue Create(T entity)
        {
            MongoCollection.InsertOne(entity);

            var result = MongoCollection.AsQueryable().First().ToBsonDocument();  // OrderByDescending(c => c.Id).First();

            return result;
        }

        public IEnumerable<T> Get()
        {
            return MongoCollection.Find<T>(item => true).ToList();
        }

        public IEnumerable<T> Get(Expression<Func<T, bool>> predicate)
        {
            return MongoCollection.Find<T>(predicate).ToList();
        }

        public IEnumerable<T> Get(Expression<Func<T, bool>> predicate, int skip = 0, int limit = int.MaxValue)
        {
            return MongoCollection.Find(predicate).Skip(skip).Limit(limit).ToList();
        }

        public T GetFirstOrDefault(Expression<Func<T, bool>> predicate)
        {
            return MongoCollection.Find(predicate).FirstOrDefault();
        }

        public bool Update(Expression<Func<T, bool>> predicate, T updatedEntity)
        {
            try {
                MongoCollection.ReplaceOne(predicate, updatedEntity);

                return true;
            } catch (Exception exception) {
                Devon4NetLogger.Error("Update operation threw an error:");
                Devon4NetLogger.Error(exception.ToString());

                return false;
            }
        }

        public int Delete(Expression<Func<T, bool>> predicate, bool deleteAllCheck = false)
        {
            if (predicate != null && !deleteAllCheck)
            {
                var deletionResult = MongoCollection.DeleteMany(predicate).DeletedCount;

                return Convert.ToInt32(deletionResult);
            }

            // MongoCollection.DeleteMany(predicate);

            if (predicate == null && deleteAllCheck)
            {
                var deletionResult = MongoCollection.DeleteMany(item => true);

                return Convert.ToInt32(deletionResult);
            }

            const string errorMessage = "Please check the predicate is null and the deleteAllCheck param as well. The provided predicate is null and the input param deleteAllCheck is to false. If you want to delete all the collection please set the deleteAllCheck param to true.";
            Devon4NetLogger.Error(errorMessage);
            throw new ArgumentException(errorMessage);
        }
    }
}

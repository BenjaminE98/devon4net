using MongoDB.Bson;
using System.Linq.Expressions;

namespace Devon4Net.Infrastructure.MongoDb.Repository
{
    public interface IMongoDbRepository<T>
    {
        BsonValue Create(T entity);
        bool Update(Expression<Func<T, bool>> predicate, T entity);
        int Delete(Expression<Func<T, bool>> predicate, bool deleteAllCheck = false);
        IEnumerable<T> Get();
        IEnumerable<T> Get(Expression<Func<T, bool>> predicate, int skip = 0, int limit = int.MaxValue);
        T GetFirstOrDefault(Expression<Func<T, bool>> predicate);
        // T GetFirstOrDefault(Query query);
    }
}
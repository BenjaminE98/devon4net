using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

using MongoDB.Driver;

namespace Devon4Net.Infrastructure.MongoDb.Repository
{
    public interface IRepository<T>
    {
        void Create(T entity);
        
        IEnumerable<T> Get();

        IEnumerable<T> Get(Expression<Func<T, bool>> predicate);

        T GetFirstOrDefault(Expression<Func<T, bool>> predicate);

        void Update(Expression<Func<T, bool>> predicate, T updatedEntity);

        void Delete(Expression<Func<T, bool>> predicate);

        // Async?

        //Task<IReadOnlyCollection<T>> GetAllAsync();
    }
}

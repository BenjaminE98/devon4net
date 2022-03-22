using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MongoDB.Driver;

namespace Devon4Net.Infrastructure.MongoDb.Repository
{
    public interface IRepository<T>
    {
        IEnumerable<T> Get();
    }
}

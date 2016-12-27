using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Driver;

namespace XH.Infrastructure.Persistence.MongoDb
{
    public interface IMongoDatabaseProvider
    {
        IMongoDatabase Database { get; }
    }
}
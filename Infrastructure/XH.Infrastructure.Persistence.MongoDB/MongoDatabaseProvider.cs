using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XH.Infrastructure.Persistence.MongoDb.Configuration;

namespace XH.Infrastructure.Persistence.MongoDb
{
    public class MongoDatabaseProvider : IMongoDatabaseProvider
    {
        private readonly IMongoDbConfiguration _config;

        public MongoDatabaseProvider(IMongoDbConfiguration config)
        {

        }
    }
}

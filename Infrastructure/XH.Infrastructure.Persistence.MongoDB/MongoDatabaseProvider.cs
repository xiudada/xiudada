using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Driver;
using XH.Infrastructure.Persistence.MongoDb.Configuration;

namespace XH.Infrastructure.Persistence.MongoDb
{
    public class MongoDatabaseProvider : IMongoDatabaseProvider
    {
        private readonly IMongoDbConfiguration _config;
        private readonly IMongoClient _client;
        private IMongoDatabase _database;

        public MongoDatabaseProvider(IMongoDbConfiguration config)
        {
            _config = config;
            _client = new MongoClient(config.ConnectionString);
        }

        public IMongoDatabase Database
        {
            get
            {
                if (_database == null)
                {
                    _database = _client.GetDatabase(_config.DatabaseName);
                }

                return _database;
            }
        }
    }
}

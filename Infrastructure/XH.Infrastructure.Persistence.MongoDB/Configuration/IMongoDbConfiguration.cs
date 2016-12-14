using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XH.Infrastructure.Persistence.MongoDb.Configuration
{
    public interface IMongoDbConfiguration
    {
        string ConnectionString { get; set; }

        string DatabaseName { get; set; }
    }
}

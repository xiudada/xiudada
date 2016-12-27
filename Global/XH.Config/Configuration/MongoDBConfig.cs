using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XH.Configurations
{
    public class MongoDBConfig : IConfiguration
    {
        public string ConnectionString { get; set; }

        public string DatabaseName { get; set; }

        public bool IsValid()
        {
            return !String.IsNullOrEmpty(ConnectionString) && !String.IsNullOrEmpty(DatabaseName);
        }
    }
}

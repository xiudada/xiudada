using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using XH.Infrastructure.Dependency;
using XH.Infrastructure.Persistence.MongoDb.Configuration;
using XH.Infrastructure.Persistence.MongoDb;
using XH.Infrastructure.Persistence.MongoDb.Repositories;
using XH.Infrastructure.Domain.Repositories;

namespace XH.Config
{
    public class WebApiConfigurationRegistrar : IDependencyRegistrar
    {
        public int Priority { get { return 100; } }

        public void Register(ContainerBuilder builder, IDependencyRegistrarContext context)
        {
            builder.RegisterInstance(new MongoDbConfiguration
            {
                ConnectionString = "mongodb://xiudada:9527@localhost:27017",
                DatabaseName = "xiudada"
            }).As<IMongoDbConfiguration>();

            builder.RegisterType<MongoDatabaseProvider>().As<IMongoDatabaseProvider>();
            builder.RegisterGeneric(typeof(MongoDbRepositoryBase<>)).As(typeof(IRepository<>)).InstancePerLifetimeScope();
        }
    }
}

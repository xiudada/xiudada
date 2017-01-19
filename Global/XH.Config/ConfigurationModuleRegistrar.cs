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
using AutoMapper;
using XH.Infrastructure.Reflection;
using XH.Infrastructure.Mapper;
using XH.Infrastructure.Caching;

namespace XH.Configurations
{
    public class ConfigurationModuleRegistrar : IDependencyRegistrar
    {
        private readonly ITypeFinder _typeFinder;

        public int Priority { get { return 1; } }

        public ConfigurationModuleRegistrar()
        {
            _typeFinder = new WebAppTypeFinder();
            //IocManager.Instance.IocContainer.Resolve<ITypeFinder>();
        }

        public void Register(ContainerBuilder builder, IDependencyRegistrarContext context)
        {
            RegisterMongoDB(builder, context);
            RegisterAutomapper(builder, context);

            builder.RegisterType<MemoryCacheManager>().As<ICacheManager>();
        }

        private void RegisterMongoDB(ContainerBuilder builder, IDependencyRegistrarContext context)
        {
            builder.RegisterType<LocalConfigurationProvider>().As<IConfigurationProvider>();
            builder.RegisterType<MongoDbConfiguration>().As<IMongoDbConfiguration>();
            builder.RegisterType<MongoDatabaseProvider>().As<IMongoDatabaseProvider>();
            builder.RegisterGeneric(typeof(MongoDbRepositoryBase<>)).As(typeof(IRepository<>)).InstancePerLifetimeScope();
        }

        private void RegisterAutomapper(ContainerBuilder builder, IDependencyRegistrarContext context)
        {
            var container = context.IocManager.IocContainer;
            var mapperRegistrarTypes = _typeFinder.FindClassesOfType<IAutoMapperRegistrar>(true);
            Mapper.Initialize(cfg =>
            {
                using (var scope = container.BeginLifetimeScope())
                {
                    foreach (var type in mapperRegistrarTypes)
                    {
                        object registrar = null;
                        if (container.TryResolve(type, out registrar))
                        {
                            ((IAutoMapperRegistrar)registrar).Register(cfg);
                        }
                    }
                }
            });

            // After create map
            builder.RegisterInstance(Mapper.Instance).As<IMapper>().SingleInstance();
        }
    }
}

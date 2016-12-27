using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using XH.Configurations;
using XH.Infrastructure.Dependency;
using Autofac;
using XH.Infrastructure.Caching;

namespace XH.Config.Tests.Configuration
{
    [TestClass]
    public class LocalConfigurationProvider_Tests
    {
        [TestInitialize]
        public void Initialize()
        {
            IocManager.Instance.Initialize(RegisterDependencies);
        }

        [TestMethod]
        public void LoadConfiguration_Tests()
        {
            IConfigurationProvider provider = IocManager.Instance.IocContainer.Resolve<IConfigurationProvider>();
            MongoDBConfig config = provider.GetConfiguration<MongoDBConfig>();

            int i = 0;
        }

        [TestMethod]
        public void SaveConfiguration_Tests()
        {
            IConfigurationProvider provider = IocManager.Instance.IocContainer.Resolve<IConfigurationProvider>();
            MongoDBConfig config = provider.GetConfiguration<MongoDBConfig>();

            config.DatabaseName = "huang";
            provider.SaveConfiguration(config);
            int i = 0;
        }

        private void RegisterDependencies(ContainerBuilder builder, IDependencyRegistrarContext context)
        {
            builder.RegisterType<LocalConfigurationProvider>().As<IConfigurationProvider>();
            builder.RegisterType<MemoryCacheManager>().As<ICacheManager>();
        }
    }
}
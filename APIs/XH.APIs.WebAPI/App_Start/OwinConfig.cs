using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using Autofac;
using Autofac.Integration.WebApi;
using Owin;
using XH.Commands;
using XH.Configurations;
using XH.Infrastructure.Dependency;
using XH.Infrastructure.Persistence.MongoDb.Configuration;
using XH.Queries;

namespace XH.APIs.WebAPI
{
    /// <summary>
    /// OWIN config
    /// </summary>
    public class OwinConfig
    {
        /// <summary>
        /// Configure
        /// </summary>
        /// <param name="app"></param>
        /// <param name="config"></param>
        public static void Configure(IAppBuilder app, HttpConfiguration config)
        {
            config.IncludeErrorDetailPolicy = IncludeErrorDetailPolicy.Always;
            WebApiConfig.Register(config);

            LoadDependencyModules();
            // load dependency modules
            IocManager.Instance.Initialize(InitConfiguartion);

            config.DependencyResolver = new AutofacWebApiDependencyResolver(IocManager.Instance.IocContainer);
            app.UseAutofacMiddleware(IocManager.Instance.IocContainer);
            app.UseAutofacWebApi(config);
            app.UseWebApi(config);
        }

        private static void LoadDependencyModules()
        {
            var queryModule = typeof(QueryModuleDependencyRegistrar);
            var commandModule = typeof(CommandModuleDependencyRegistrar);
            var configuModule = typeof(ConfigurationModuleRegistrar);
        }

        private static void InitConfiguartion(ContainerBuilder builder, IDependencyRegistrarContext context)
        {
            // Config connection string
            builder.Register<MongoDbConfiguration>(c =>
            {
                var configurationProvice = c.Resolve<IConfigurationProvider>();
                var mongoConfiguration = configurationProvice.GetConfiguration<MongoDBConfig>();
                return new MongoDbConfiguration
                {
                    ConnectionString = mongoConfiguration.ConnectionString,
                    DatabaseName = mongoConfiguration.DatabaseName
                };

            }).As<IMongoDbConfiguration>();
        }
    }
}
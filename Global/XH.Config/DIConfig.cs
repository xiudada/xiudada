using Autofac;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XH.Infrastructure.Query;

namespace XH.Config
{
    public class DIConfig
    {
        private static IContainer _configuredContainer;

        /// <summary>
        /// Get configured container
        /// </summary>
        /// <returns></returns>
        public static IContainer GetConfiguredContainer()
        {
            Contract.Assert(_configuredContainer != null);
            return _configuredContainer;
        }

        /// <summary>
        /// Register components
        /// </summary>
        /// <param name="register"></param>
        public static IContainer RegisterComponents(Action<ContainerBuilder> register = null)
        {
            ContainerBuilder containerBuilder = new ContainerBuilder();

            // Register components
            RegisterPersistence(containerBuilder);
            RegisterCommandHandlers(containerBuilder);
            RegisterEventHandlers(containerBuilder);
            RegisterQueryHandlers(containerBuilder);
            RegisterComponents(containerBuilder);

            if (register != null)
            {
                register(containerBuilder);
            }

            // Create a container
            _configuredContainer = containerBuilder.Build();
            return _configuredContainer;
        }

        private static void RegisterPersistence(ContainerBuilder container)
        {

        }

        private static void RegisterCommandHandlers(ContainerBuilder container)
        {

        }

        private static void RegisterEventHandlers(ContainerBuilder container)
        {

        }

        private static void RegisterQueryHandlers(ContainerBuilder container)
        {
            container.RegisterType<InMemoryQueryBus>().As<IQueryBus>();


        }

        private static void RegisterComponents(ContainerBuilder container)
        {

        }

    }
}

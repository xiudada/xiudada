using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using XH.Infrastructure.Bus;

namespace XH.Infrastructure.Dependency
{
    public class CoreDependencyRegistrar : IDependencyRegistrar
    {
        public int Priority
        {
            get { return 1000; }
        }

        public void Register(ContainerBuilder containerBuilder, IDependencyRegistrarContext context)
        {
            containerBuilder.RegisterType<InMemoryQueryBus>().As<IQueryBus>();
            containerBuilder.RegisterType<InMemoryCommandBus>().As<ICommandBus>();
            containerBuilder.RegisterType<InMemoryEventBus>().As<IEventBus>();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using XH.Infrastructure.Reflection;

namespace XH.Infrastructure.Dependency
{
    public class IocManager : IIocManager
    {
        public static IocManager Instance = new IocManager(null);

        private readonly ITypeFinder _typeFinder;
        private bool _isInitialized = false;
        private IDependencyRegistrarContext _registrarContext;

        public IContainer IocContainer { get; set; }

        public ITypeFinder TypeFinder { get; set; }

        public IocManager(ITypeFinder typeFinder)
        {
            _typeFinder = typeFinder ?? new AppDomainTypeFinder();
        }

        public void Initialize(Action<ContainerBuilder, IDependencyRegistrarContext> buildAction = null)
        {
            if (!_isInitialized)
            {
                ContainerBuilder containerBuilder = new ContainerBuilder();
                _registrarContext = new DependencyRegistrarContext(this);
                IocContainer = RegisterCore(containerBuilder, _registrarContext);
                // Get all registrars;
                RegisterDependencies();

                var container = new ContainerBuilder();
                buildAction?.Invoke(container, _registrarContext);

                container.Update(IocContainer);
                _isInitialized = true;
            }
        }

        public void Register(Action<ContainerBuilder, IDependencyRegistrarContext> buildAction)
        {
            var builder = new ContainerBuilder();
            buildAction?.Invoke(builder, _registrarContext);
            builder.Update(IocContainer);
        }

        private IContainer RegisterCore(ContainerBuilder containerBuilder, IDependencyRegistrarContext context)
        {
            // Register self
            containerBuilder.Register(component => this).As<IIocManager>().SingleInstance();
            containerBuilder.RegisterInstance(context).As<IDependencyRegistrarContext>();
            containerBuilder.RegisterInstance(_typeFinder).As<ITypeFinder>();

            return containerBuilder.Build();
        }

        private void RegisterDependencies()
        {
            
            var registrarTypes = _typeFinder.FindClassesOfType<IDependencyRegistrar>(true);
            List<IDependencyRegistrar> registrars = new List<IDependencyRegistrar>();

            foreach (var type in registrarTypes)
            {
                registrars.Add((IDependencyRegistrar)Activator.CreateInstance(type));
            }

            registrars = registrars.OrderByDescending(it => it.Priority).ToList();
            foreach (var registrar in registrars)
            {
                var containerBuilder = new ContainerBuilder();
                registrar.Register(containerBuilder, _registrarContext);
                containerBuilder.Update(IocContainer);
            }
        }
    }
}

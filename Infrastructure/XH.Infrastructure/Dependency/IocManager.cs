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

        public IContainer IocContainer { get; set; }

        public ITypeFinder TypeFinder { get; set; }

        public IocManager(ITypeFinder typeFinder)
        {
            _typeFinder = typeFinder ?? new AppDomainTypeFinder();
        }

        public void Initialize()
        {
            if (!_isInitialized)
            {
                ContainerBuilder containerBuilder = new ContainerBuilder();
                RegisterSelf(containerBuilder);

                // Get all registrars;
                RegisterDependencies(containerBuilder);
                IocContainer = containerBuilder.Build();
                _isInitialized = true;
            }
        }

        private void RegisterSelf(ContainerBuilder containerBuilder)
        {
            // Register self
            containerBuilder.Register(component => this).As<IIocManager>().SingleInstance();
        }

        private void RegisterDependencies(ContainerBuilder containerBuilder)
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
                registrar.Register(containerBuilder, new DependencyRegistrarContext(this));
            }
        }
    }
}

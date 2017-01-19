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
                ContainerBuilder builder = new ContainerBuilder();
                _registrarContext = new DependencyRegistrarContext(this);
                builder.Register(component => this).As<IIocManager>().SingleInstance();
                builder.RegisterInstance(_registrarContext).As<IDependencyRegistrarContext>();
                builder.RegisterInstance(_typeFinder).As<ITypeFinder>();

                IocContainer = builder.Build();

                // Get all registrars
                RegisterDependencies();

                builder = new ContainerBuilder();
                buildAction?.Invoke(builder, _registrarContext);

                builder.Update(IocContainer);
                _isInitialized = true;
            }
        }

        public void Register(Action<ContainerBuilder, IDependencyRegistrarContext> buildAction)
        {
            var builder = new ContainerBuilder();
            buildAction?.Invoke(builder, _registrarContext);
            builder.Update(IocContainer);
        }

        private void RegisterDependencies()
        {
            var registrarTypes = _typeFinder.FindClassesOfType<IDependencyRegistrar>(true);
            List<IDependencyRegistrar> registrars = new List<IDependencyRegistrar>();

            foreach (var type in registrarTypes)
            {
                // TODO: what if dependencyRegistrar has dependencies ?
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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using Autofac;
using Autofac.Integration.WebApi;
using XH.Infrastructure.Dependency;

namespace XH.APIs.WebAPI.App_Start
{
    public class WebApiDependencyRegistrar : IDependencyRegistrar
    {
        public int Priority
        {
            get
            {
                return 1;
            }
        }

        public void Register(ContainerBuilder builder, IDependencyRegistrarContext context)
        {
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());
            builder.RegisterType<WebApiAutoMapperRegistrar>();
        }
    }
}
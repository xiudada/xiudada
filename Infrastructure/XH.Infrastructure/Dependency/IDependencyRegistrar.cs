using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;

namespace XH.Infrastructure.Dependency
{
    public interface IDependencyRegistrar
    {
        void Register(ContainerBuilder builder, IDependencyRegistrarContext context);

        /// <summary>
        /// 优先级
        /// </summary>
        int Priority { get; }
    }
}

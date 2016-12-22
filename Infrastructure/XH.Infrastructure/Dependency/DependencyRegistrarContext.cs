using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XH.Infrastructure.Dependency
{
    public class DependencyRegistrarContext : IDependencyRegistrarContext
    {
        public IIocManager IocManager { get; set; }

        public DependencyRegistrarContext(IIocManager iocManager)
        {
            IocManager = iocManager;
        }
    }
}

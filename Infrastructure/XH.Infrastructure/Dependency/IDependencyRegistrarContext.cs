using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XH.Infrastructure.Dependency
{
    public interface IDependencyRegistrarContext
    {
        IIocManager IocManager { get; set; }
    }
}

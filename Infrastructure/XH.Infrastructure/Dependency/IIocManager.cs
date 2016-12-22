using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;

namespace XH.Infrastructure.Dependency
{
    public interface IIocManager
    {
        IContainer IocContainer { get; set; }
    }
}

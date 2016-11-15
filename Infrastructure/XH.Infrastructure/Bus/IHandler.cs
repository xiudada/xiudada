using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XH.Infrastructure.Bus
{
    public interface IHandler<in T, out TResult>
    {
        TResult Handle(T parameter);
    }

    public interface IHandler<in T>
    {
        void Handle(T parameter);
    }
}

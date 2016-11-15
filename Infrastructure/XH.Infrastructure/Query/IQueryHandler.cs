using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XH.Infrastructure.Bus;

namespace XH.Infrastructure.Query
{
    public interface IQueryHandler<in T, out TResult> : IHandler<T, TResult> where T : IQuery
    {
    }
}

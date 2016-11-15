using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XH.Infrastructure.Query;

namespace XH.Infrastructure.Bus
{
    /// <summary>
    ///
    /// </summary>
    public interface IQueryBus : IBus
    {
        TQueryResult Send<TQuery, TQueryResult>(TQuery query) where TQuery : IQuery;
    }
}

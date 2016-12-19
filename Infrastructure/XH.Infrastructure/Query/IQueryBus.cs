using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XH.Infrastructure.Query
{
    public interface IQueryBus
    {
        /// <summary>
        /// Send the query
        /// </summary>
        /// <typeparam name="TQuery"></typeparam>
        /// <typeparam name="TQueryResult"></typeparam>
        /// <param name="query"></param>
        TQueryResult Send<TQuery, TQueryResult>(TQuery query) where TQuery : IQuery;
    }
}

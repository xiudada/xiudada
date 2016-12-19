using Autofac;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XH.Infrastructure.Query;

namespace XH.Infrastructure.Query
{
    public class InMemoryQueryBus : IQueryBus
    {
        private readonly IComponentContext _componentContext;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="componentContext"></param>
        public InMemoryQueryBus(IComponentContext componentContext)
        {
            _componentContext = componentContext;
        }

        public TQueryResult Send<TQuery, TQueryResult>(TQuery query) where TQuery : IQuery
        {
            IQueryHandler<TQuery, TQueryResult> queryHandler = _componentContext.Resolve<IQueryHandler<TQuery, TQueryResult>>();
            Contract.Assert(queryHandler != null);

            return queryHandler.Handle(query);
        }
    }
}

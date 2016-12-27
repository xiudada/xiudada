using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XH.Infrastructure.Dependency;
using Autofac;
using XH.Queries.Articles.QueryHanlders;
using XH.Infrastructure.Query;
using XH.Queries.Articles.Queries;
using XH.Queries.Articles.Dtos;
using XH.Queries.Articles.Configs;
using XH.Infrastructure.Mapper;

namespace XH.Queries
{
    public class QueryModuleDependencyRegistrar : IDependencyRegistrar
    {
        public int Priority
        {
            get
            {
                return 1000;
            }
        }

        public void Register(ContainerBuilder containerBuilder, IDependencyRegistrarContext context)
        {
            containerBuilder.RegisterType<ArticleQueryHandler>().As<IQueryHandler<GetArticleQuery, ArticleDto>>();
            containerBuilder.RegisterType<AritclesMapperRegistrar>();
        }
    }
}

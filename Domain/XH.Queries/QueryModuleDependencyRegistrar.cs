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
using XH.Infrastructure.Paging;
using XH.Queries.Categories.Configs;
using XH.Queries.Categories.QueryHanlders;
using XH.Queries.Categories.Queries;
using XH.Queries.Categories.Dtos;

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
            // articles
            containerBuilder.RegisterType<ArticleQueryHandler>().As<IQueryHandler<GetArticleQuery, ArticleDto>>();
            containerBuilder.RegisterType<ArticleQueryHandler>().As<IQueryHandler<ListArticlesQuery, PagedList<ArticleOverviewDto>>>();

            // categories
            containerBuilder.RegisterType<CategoriesQueryHandler>().As<IQueryHandler<ListCategoriesQuery, IEnumerable<CategoryOverviewDto>>>();
            containerBuilder.RegisterType<CategoriesQueryHandler>().As<IQueryHandler<GetCategoryQuery, CategoryDto>>();
            containerBuilder.RegisterType<CategoriesQueryHandler>().As<IQueryHandler<GetCategoriesTreeQuery, IEnumerable<CategoriesTreeNode>>>();

            containerBuilder.RegisterType<AritclesMapperRegistrar>();
            containerBuilder.RegisterType<CategoriesMapperRegistrar>();
        }
    }
}

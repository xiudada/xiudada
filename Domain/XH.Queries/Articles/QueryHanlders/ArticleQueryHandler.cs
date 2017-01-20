using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XH.Domain.Catalogs.Models;
using XH.Infrastructure.Domain.Repositories;
using XH.Infrastructure.Extensions;
using XH.Infrastructure.Paging;
using XH.Infrastructure.Query;
using XH.Queries.Articles.Dtos;
using XH.Queries.Articles.Queries;

namespace XH.Queries.Articles.QueryHanlders
{
    public class ArticleQueryHandler :
        IQueryHandler<GetArticleQuery, ArticleDto>,
        IQueryHandler<ListArticlesQuery, PagedList<ArticleOverviewDto>>
    {
        private IRepository<Article> _articleRepository;
        private IMapper _mapper;

        public ArticleQueryHandler(
            IRepository<Article> articleRepository,
            IMapper mapper)
        {
            _articleRepository = articleRepository;
            _mapper = mapper;
        }

        public ArticleDto Handle(GetArticleQuery query)
        {
            var article = _articleRepository.Get(query.Id);
            return _mapper.Map<ArticleDto>(article);
        }

        public PagedList<ArticleOverviewDto> Handle(ListArticlesQuery query)
        {
            return _articleRepository.GetAll()
                    .Sort(query.SortItems)
                    .ToPagedList<Article, ArticleOverviewDto>(query.Page, query.PageSize);
        }
    }
}

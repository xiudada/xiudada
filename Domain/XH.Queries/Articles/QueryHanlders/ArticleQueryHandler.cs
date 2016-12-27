using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XH.Domain.Catalogs.Models;
using XH.Infrastructure.Domain.Repositories;
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
            return new ArticleDto
            {
                Id = query.Id,
                Title = "test article"
            };
        }

        public PagedList<ArticleOverviewDto> Handle(ListArticlesQuery query)
        {
            var articles = _mapper.Map<IEnumerable<ArticleOverviewDto>>(_articleRepository.GetAll().ToList());
            return new PagedList<ArticleOverviewDto>(articles, query.Page, query.PageSize, articles.Count());
        }
    }
}

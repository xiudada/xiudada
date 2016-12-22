using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XH.Infrastructure.Query;
using XH.Queries.Articles.Dtos;
using XH.Queries.Articles.Queries;

namespace XH.Queries.Articles.QueryHanlders
{
    public class ArticleQueryHandler :
        IQueryHandler<GetArticleQuery, ArticleDto>
    {
        public ArticleQueryHandler()
        {
        }

        public ArticleDto Handle(GetArticleQuery query)
        {
            return new ArticleDto
            {
                Id = query.Id,
                Title = "test article"
            };
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XH.Infrastructure.Query;

namespace XH.Queries.Articles.Queries
{
    public class GetArticleQuery : QueryBase
    {
        public string Id { get; set; }
    }
}

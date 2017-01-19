using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XH.Infrastructure.Query;

namespace XH.Queries.Categories.Queries
{
    public class GetCategoriesTreeQuery : QueryBase
    {
        public string RootNodeId { get; set; }
    }
}

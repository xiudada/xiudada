using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XH.Infrastructure.Query
{
    public abstract class ListQueryBase : QueryBase, IListQuery
    {
        public int Page { get; set; }

        public int PageSize { get; set; }

        public ICollection<SortItem> SortItems { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XH.Infrastructure.Query
{
    public interface IListQuery
    {
        int Page { get; set; }

        int PageSize { get; set; }

        ICollection<SortItem> SortItems { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XH.Infrastructure.Paging;

namespace XH.Infrastructure.Extensions
{
    public static class PagedListExtensions
    {
        public static PagedList<TDest> MapTo<TDest>(this IPagedList<object> pagedList)
        {
            return new PagedList<TDest>(pagedList.Items.Select(it => AutoMapper.Mapper.Map<TDest>(it)), pagedList.Page, pagedList.PageSize, pagedList.TotalItemCount);
        }
    }
}

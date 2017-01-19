using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XH.Infrastructure.Paging;

namespace XH.Infrastructure.Extensions
{
    public static class QueryableExtensions
    {
        /// <summary>
        /// To paged list
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="allItems"></param>
        /// <param name="page"></param>
        /// <param name="pageSize"></param>
        /// <param name="totalItemCount"></param>
        /// <returns></returns>
        public static PagedList<T> ToPagedList<T>(this IQueryable<T> allItems, int page, int pageSize, int? totalItemCount = null)
        {
            if (!totalItemCount.HasValue)
            {
                totalItemCount = allItems.Count();
            }

            int pageCount = (int)Math.Ceiling((double)totalItemCount / pageSize);
 
            // The method 'OrderBy' must be called before the method 'Skip'
            IEnumerable<T> items = allItems.Skip((page - 1) * pageSize).Take(pageSize).ToList();
            return new PagedList<T>(items, page, pageSize, totalItemCount.Value);
        }
    }
}

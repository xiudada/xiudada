using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XH.Infrastructure.Paging;
using XH.Infrastructure.Query;
using XH.Shared.Enums;

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

        /// <summary>
        /// To paged list
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="allItems"></param>
        /// <param name="page"></param>
        /// <param name="pageSize"></param>
        /// <param name="totalItemCount"></param>
        /// <returns></returns>
        public static PagedList<TDest> ToPagedList<TSource, TDest>(this IQueryable<TSource> allItems, int page, int pageSize, int? totalItemCount = null)
        {
            if (!totalItemCount.HasValue)
            {
                totalItemCount = allItems.Count();
            }

            int pageCount = (int)Math.Ceiling((double)totalItemCount / pageSize);

            IEnumerable<TDest> items = AutoMapper.Mapper.Map<IEnumerable<TDest>>(allItems.Skip((page - 1) * pageSize).Take(pageSize).ToList());
            //IEnumerable<TDest> items = allItems.Skip((page - 1) * pageSize).Take(pageSize).Select(it => AutoMapper.Mapper.Map<TDest>(it)).ToList();

            return new PagedList<TDest>(items, page, pageSize, totalItemCount.Value);
        }



        /// <summary>
        /// ##TODO: now do nothing
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="allItems"></param>
        /// <param name="sortItems"></param>
        /// <returns></returns>
        public static IQueryable<T> Sort<T>(this IQueryable<T> allItems, IEnumerable<SortItem> sortItems)
        {
            //string ordering = String.Empty;

            //if (sortItems != null)
            //{
            //    foreach (SortItem sortItem in sortItems)
            //    {
            //        if (!String.IsNullOrWhiteSpace(ordering))
            //        {
            //            ordering += ",";
            //        }

            //        if (sortItem.SortDirection == SortDirection.Asc)
            //        {
            //            ordering += sortItem.SortBy;
            //        }
            //        else
            //        {
            //            ordering += String.Format("{0} desc", sortItem.SortBy);
            //        }
            //    }
            //}

            //if (!String.IsNullOrWhiteSpace(ordering))
            //{
            //    allItems = allItems.OrderBy(ordering);
            //}

            return allItems;
        }
    }
}

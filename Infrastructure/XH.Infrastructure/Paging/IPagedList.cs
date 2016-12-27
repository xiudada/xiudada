using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XH.Infrastructure.Paging
{
    /// <summary>
    /// Paged list interface
    /// </summary>
    public interface IPagedList<T>
    {
        IEnumerable<T> Items { get; }

        /// <summary>
        /// Page
        /// </summary>
        int Page { get; }

        /// <summary>
        /// Page size
        /// </summary>
        int PageSize { get; }

        /// <summary>
        /// Total item count
        /// </summary>
        int TotalItemCount { get; }

        /// <summary>
        /// Start item index
        /// </summary>
        int StartItemIndex { get; }

        /// <summary>
        /// End item index
        /// </summary>
        int EndItemIndex { get; }

        /// <summary>
        /// Page count
        /// </summary>
        int PageCount { get; }

        /// <summary>
        /// Has previous page
        /// </summary>
        bool HasPreviousPage { get; }

        /// <summary>
        /// Has next page
        /// </summary>
        bool HasNextPage { get; }
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XH.Infrastructure.Paging
{
    public class PagedList<T> : IPagedList<T>
    {
        private readonly IEnumerable<T> _items;
        private readonly int _page;
        private readonly int _pageSize;
        private readonly int _totalItemCount;
        private int? _pageCount;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="items"></param>
        /// <param name="page"></param>
        /// <param name="pageSize"></param>
        /// <param name="totalItemCount"></param>
        public PagedList(IEnumerable<T> items, int page, int pageSize, int totalItemCount)
        {
            _items = items;
            _page = page;
            _pageSize = pageSize;
            _totalItemCount = totalItemCount;
        }

        /// <summary>
        /// Page
        /// </summary>
        public int Page
        {
            get
            {
                return _page;
            }
        }

        /// <summary>
        /// Page size
        /// </summary>
        public int PageSize
        {
            get
            {
                return _pageSize;
            }
        }

        /// <summary>
        /// Total item count
        /// </summary>
        public int TotalItemCount
        {
            get
            {
                return _totalItemCount;
            }
        }

        /// <summary>
        /// Start item index
        /// </summary>
        public int StartItemIndex
        {
            get
            {
                int startItemIndex = ((Page - 1) * PageSize) + 1;
                if (startItemIndex > TotalItemCount)
                {
                    startItemIndex = TotalItemCount;
                }

                return startItemIndex;
            }
        }

        /// <summary>
        /// End item index
        /// </summary>
        public int EndItemIndex
        {
            get
            {
                int endItemIndex = Page * PageSize;
                if (endItemIndex > TotalItemCount)
                {
                    endItemIndex = TotalItemCount;
                }

                return endItemIndex;
            }
        }

        /// <summary>
        /// Page count
        /// </summary>
        public int PageCount
        {
            get
            {
                if (!_pageCount.HasValue)
                {
                    _pageCount = (int)Math.Ceiling((double)TotalItemCount / PageSize);
                }

                return _pageCount.Value;
            }
        }

        /// <summary>
        /// Has previous page
        /// </summary>
        public bool HasPreviousPage
        {
            get
            {
                return Page > 1;
            }
        }

        /// <summary>
        /// Has next page
        /// </summary>
        public bool HasNextPage
        {
            get
            {
                return Page < PageCount;
            }
        }

        public IEnumerable<T> Items
        {
            get
            {
                return _items;
            }
        }
    }
}

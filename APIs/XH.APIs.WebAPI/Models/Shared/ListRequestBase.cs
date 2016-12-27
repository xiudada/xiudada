using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;
using XH.Infrastructure.Query;

namespace XH.APIs.WebAPI.Models
{
    /// <summary>
    /// List request base
    /// </summary>
    [DataContract]
    public class ListRequestBase
    {
        /// <summary>
        /// TO DO, In setting
        /// </summary>
        public ListRequestBase()
        {
            Page = 1;
            PageSize = 15;
        }

        /// <summary>
        /// Sorts
        /// </summary>
        [DataMember]
        public List<SortItem> Sorts { get; set; }

        /// <summary>
        /// Page
        /// </summary>
        [DataMember]
        public int Page { get; set; }

        /// <summary>
        /// Page size
        /// </summary>
        [DataMember]
        public int PageSize { get; set; }
    }
}
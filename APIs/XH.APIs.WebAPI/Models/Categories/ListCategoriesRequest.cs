using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace XH.APIs.WebAPI.Models.Categories
{
    /// <summary>
    /// list categories
    /// </summary>
    [DataContract]
    public class ListCategoriesRequest : ListRequestBase
    {
        /// <summary>
        /// Parent id
        /// </summary>
        [DataMember]
        public string ParentId { get; set; }
    }
}
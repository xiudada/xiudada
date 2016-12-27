using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace XH.APIs.WebAPI.Models.Articles
{
    /// <summary>
    /// Create or update article request base
    /// </summary>
    [DataContract]
    public class CreateOrUpdateArticleRequestBase
    {
        /// <summary>
        /// Title
        /// </summary>
        [DataMember]
        public string Title { get; set; }

        /// <summary>
        /// Content
        /// </summary>
        [DataMember]
        public string Content { get; set; }
    }
}
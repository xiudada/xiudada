using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace XH.APIs.WebAPI.Models.Articles
{
    /// <summary>
    /// Create or update article request base
    /// </summary>
    public class CreateOrUpdateArticleRequestBase
    {
        /// <summary>
        /// Title
        /// </summary>
        public string Title { get; set; }
    }
}
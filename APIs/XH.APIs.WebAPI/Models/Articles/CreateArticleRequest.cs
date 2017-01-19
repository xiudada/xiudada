using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace XH.APIs.WebAPI.Models.Articles
{
    /// <summary>
    /// Create article request base
    /// </summary>
    [DataContract]
    public class CreateArticleRequest : CreateOrUpdateArticleRequestBase
    {
    }
}
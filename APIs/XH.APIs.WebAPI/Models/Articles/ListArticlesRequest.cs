using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace XH.APIs.WebAPI.Models.Articles
{
    [DataContract]
    public class ListArticlesRequest : ListRequestBase
    {
        [DataMember]
        public string Title { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        [DataMember]
        public string Id { get; set; }

        [DataMember]
        [Required]
        public string Title { get; set; }

        [DataMember]
        [Required]
        public string Content { get; set; }

        [DataMember]
        public string Author { get; set; }

        [DataMember]
        public string From { get; set; }

        [DataMember]
        public string SourceUrl { get; set; }

        [DataMember]
        public string Image { get; set; }

        [DataMember]
        public bool IsPublished { get; set; }

        [DataMember]
        public DateTime? UtcPublishDate { get; set; }

        [DataMember]
        public SEOMetaDataRequestModel Meta { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;
using XH.APIs.WebAPI.Models.Shared;

namespace XH.APIs.WebAPI.Models.Categories
{
    [DataContract]
    public class CreateOrUpdateCategoryRequest
    {
        [DataMember]
        [Required]
        public string Name { get; set; }

        [DataMember]
        [Required]
        public string Code { get; set; }

        [DataMember]
        [Required]
        public string Slug { get; set; }

        [DataMember]
        public bool IsActive { get; set; }

        [DataMember]
        public string ParentId { get; set; }

        [DataMember]
        public int DisplayOrder { get; set; }

        [DataMember]
        public SEOMetaDataRequestModel Meta { get; set; }
    }
}
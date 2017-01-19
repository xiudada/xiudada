using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace XH.APIs.WebAPI.Models.Categories
{
    [DataContract]
    public class UpdateCategoryRequest : CreateOrUpdateCategoryRequest
    {
        [DataMember]
        [Required]
        public string Id { get; set; }
    }
}
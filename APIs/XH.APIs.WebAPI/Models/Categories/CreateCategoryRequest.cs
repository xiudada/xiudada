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
    public class CreateCategoryRequest: CreateOrUpdateCategoryRequest
    {
    }
}
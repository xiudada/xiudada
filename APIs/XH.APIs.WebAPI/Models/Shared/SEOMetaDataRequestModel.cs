using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace XH.APIs.WebAPI.Models.Shared
{
    [DataContract]
    public class SEOMetaDataRequestModel
    {
        [DataMember]
        public string Title { get; set; }

        [DataMember]
        public string Description { get; set; }

        [DataMember]
        public string Keywords { get; set; }
    }
}
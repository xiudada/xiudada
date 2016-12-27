using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace XH.APIs.WebAPI.Models.Install
{
    /// <summary>
    /// UpdateMongoDbConfigurationRequest
    /// </summary>
    [DataContract]
    public class UpdateMongoDbConfigurationRequest
    {
        /// <summary>
        /// ConnectionString
        /// </summary>
        [DataMember]
        [Required]
        public string ConnectionString { get; set; }

        /// <summary>
        /// DatabaseName
        /// </summary>
        [DataMember]
        [Required]
        public string DatabaseName { get; set; }
    }
}
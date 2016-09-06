using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XH.Infrastructure.Email
{
    /// <summary>
    /// Email attachment
    /// </summary>
    public class EmailAttachment
    {
        /// <summary>
        /// Base64
        /// </summary>
        public bool Base64 { get; set; }

        /// <summary>
        /// Content
        /// </summary>
        public string ContentUrl { get; set; }

        /// <summary>
        /// Name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Type
        /// </summary>
        public string Type { get; set; }
    }
}
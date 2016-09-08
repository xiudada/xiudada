using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XH.Infrastructure.Email
{
    /// <summary>
    /// Email message
    /// </summary>
    public class EmailMessage
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public EmailMessage()
        {
            ToList = new List<EmailAddress>();
            CcList = new List<EmailAddress>();
            BccList = new List<EmailAddress>();
            ReplyToList = new List<EmailAddress>();
            Attachments = new List<EmailAttachment>();
        }

        /// <summary>
        /// Key
        /// </summary>
        public string Key { get; set; }

        /// <summary>
        /// From
        /// </summary>
        public EmailAddress From { get; set; }

        /// <summary>
        /// To list
        /// </summary>
        public List<EmailAddress> ToList { get; set; }

        /// <summary>
        /// Cc list
        /// </summary>
        public List<EmailAddress> CcList { get; set; }

        /// <summary>
        /// Bcc list
        /// </summary>
        public List<EmailAddress> BccList { get; set; }

        /// <summary>
        /// Reply to list
        /// </summary>
        public List<EmailAddress> ReplyToList { get; set; }

        /// <summary>
        /// Subject
        /// </summary>
        public string Subject { get; set; }

        /// <summary>
        /// Plain text body
        /// </summary>
        public string PlainTextBody { get; set; }

        /// <summary>
        /// Html body
        /// </summary>
        public string HtmlBody { get; set; }

        /// <summary>
        /// Attachments
        /// </summary>
        public List<EmailAttachment> Attachments { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XH.Infrastructure.Email
{
    /// <summary>
    /// Email provider interface
    /// </summary>
    public interface IEmailProvider
    {
        /// <summary>
        /// Send a mail message
        /// </summary>
        /// <param name="message"></param>
        void SendEmail(EmailMessage message);
    }
}
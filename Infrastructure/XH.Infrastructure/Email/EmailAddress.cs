using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XH.Infrastructure.Email
{
    /// <summary>
    /// Email address
    /// </summary>
    public class EmailAddress
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="address"></param>
        public EmailAddress(string address)
        {
            Address = address;
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="address"></param>
        /// <param name="displayName"></param>
        public EmailAddress(string address, string displayName)
        {
            Address = address;
            DisplayName = displayName;
        }

        /// <summary>
        /// Address
        /// </summary>
        public string Address { get; private set; }

        /// <summary>
        /// Display name
        /// </summary>
        public string DisplayName { get; private set; }
    }
}
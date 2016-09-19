using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XH.Infrastructure.Domain.Models;

namespace XH.Domain.Models.Users
{
    /// <summary>
    /// User
    /// </summary>
    public class User : FullAuditableBaseEntity
    {
        /// <summary>
        /// Name
        /// </summary>
        public virtual string FirstName { get; set; }

        /// <summary>
        /// Last name
        /// </summary>
        public virtual string LastName { get; set; }

        /// <summary>
        /// Full name
        /// </summary>
        public virtual string FullName { get; set; }

        /// <summary>
        /// Password
        /// </summary>
        public virtual string Password { get; set; }

        /// <summary>
        /// Email
        /// </summary>
        public virtual string Email { get; set; }

        /// <summary>
        /// Sex
        /// </summary>
        public virtual Gender Sex { get; set; }

        /// <summary>
        /// Role
        /// </summary>
        public virtual Role Role { get; set; }
    }
}

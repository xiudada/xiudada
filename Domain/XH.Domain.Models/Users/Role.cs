using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XH.Infrastructure.Domain.Models;

namespace XH.Domain.Models.Users
{
    /// <summary>
    /// Role
    /// </summary>
    public class Role : FullAuditableBaseEntity
    {
        /// <summary>
        /// Name
        /// </summary>
        public virtual string Name { get; set; }

        /// <summary>
        /// Permission
        /// </summary>
        public virtual ICollection<Permission> Permissions { get; set; }
    }
}

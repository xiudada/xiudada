using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XH.Infrastructure.Domain.Models;

namespace XH.Domain.Models.Users
{
    /// <summary>
    /// Permission
    /// </summary>
    public class Permission : BaseEntity
    {
        /// <summary>
        /// Permission name
        /// </summary>
        public string Name { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XH.Infrastructure.Domain.Models
{
    /// <summary>
    /// Auditable entity interface
    /// </summary>
    public interface IAuditableEntity
    {
        /// <summary>
        /// Created on
        /// </summary>
        DateTime UtcCreatedOn { get; set; }

        /// <summary>
        /// Created by user id
        /// </summary>
        string CreatedByUserId { get; set; }

        /// <summary>
        /// Modified on
        /// </summary>
        DateTime? UtcModifiedOn { get; set; }

        /// <summary>
        /// Modified by user id
        /// </summary>
        string ModifiedByUserId { get; set; }
    }
}

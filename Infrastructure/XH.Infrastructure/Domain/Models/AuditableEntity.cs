using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XH.Infrastructure.Domain.Models
{
    /// <summary>
    /// Auditable entity base
    /// </summary>
    public abstract class AuditableBaseEntity : EntityBase, IAuditable
    {
        /// <summary>
        /// Created on
        /// </summary>
        public virtual DateTime UtcCreatedOn { get; set; }

        /// <summary>
        /// Created by user id
        /// </summary>
        public virtual string CreatedBy { get; set; }

        /// <summary>
        /// Modified on
        /// </summary>
        public virtual DateTime? UtcModifiedOn { get; set; }

        /// <summary>
        /// Modified by user id
        /// </summary>
        public virtual string ModifiedBy { get; set; }
    }
}

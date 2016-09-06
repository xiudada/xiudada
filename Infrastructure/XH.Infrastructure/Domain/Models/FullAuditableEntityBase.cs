using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XH.Infrastructure.Domain.Models
{
    /// <summary>
    /// Full auditable entity base
    /// </summary>
    public abstract class FullAuditableEntityBase : AuditableEntityBase, IFullAuditableEntity
    {
        /// <summary>
        /// Is deleted
        /// </summary>
        public virtual bool IsDeleted { get; set; }

        /// <summary>
        /// Deleted on
        /// </summary>
        public virtual DateTime? UtcDeletedOn { get; set; }

        /// <summary>
        /// Deleted by user id
        /// </summary>
        public virtual string DeletedByUserId { get; set; }
    }
}

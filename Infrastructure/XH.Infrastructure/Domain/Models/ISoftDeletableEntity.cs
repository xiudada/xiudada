using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XH.Infrastructure.Domain.Models
{
    /// <summary>
    /// Soft deletable entity
    /// </summary>
    public interface ISoftDeletableEntity
    {
        /// <summary>
        /// Is deleted
        /// </summary>
        bool IsDeleted { get; set; }

        /// <summary>
        /// Deleted on
        /// </summary>
        DateTime? UtcDeletedOn { get; set; }

        /// <summary>
        /// Deleted by user id
        /// </summary>
        string DeletedByUserId { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XH.Infrastructure.Domain.Models
{
    /// <summary>
    /// Full auditable entity
    /// </summary>
    public interface IFullAuditableEntity : IAuditable, ISoftDeletableEntity
    {
    }
}

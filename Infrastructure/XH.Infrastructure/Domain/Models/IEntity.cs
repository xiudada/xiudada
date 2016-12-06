using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XH.Infrastructure.Domain.Models
{
    /// <summary>
    /// When user string(GUID) as primary key
    /// </summary>
    public interface IEntity : IEntity<string>
    {
    }
}

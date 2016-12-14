using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XH.Infrastructure.Domain.Models
{
    public interface IAggregateRoot
    {
        string Id { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XH.Console.NH.BookChoice
{
    public interface ICustomAttributeResolver
    {
        Dictionary<string, object> ResolveCustomAttribute(object @object);
    }
}

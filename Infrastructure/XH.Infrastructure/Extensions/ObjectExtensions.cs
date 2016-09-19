using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XH.Infrastructure.Extensions
{
    /// <summary>
    /// Object extensions
    /// </summary>
    public static class ObjectExtensions
    {
        /// <summary>
        /// To
        /// </summary>
        /// <typeparam name="ToType"></typeparam>
        /// <param name="obj"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        public static ToType To<ToType>(this object obj, ToType defaultValue = default(ToType))
        {
            ToType to = default(ToType);

            return to;
        }
    }
}

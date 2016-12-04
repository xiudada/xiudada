using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XH.Infrastructure.Extensions
{
    /// <summary>
    /// String extensions
    /// </summary>
    public static class StringExtensions
    {
        public static string FormatWith(this string format, params object[] args)
        {
            return String.Format(format, args);
        }
    }
}
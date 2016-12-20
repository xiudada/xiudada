using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XH.Console.NH.BookChoice
{
    [AttributeUsage(AttributeTargets.Property)]
    public class CustomAttributeFieldAttribute : Attribute
    {
        public CustomAttributeFieldAttribute() : this(String.Empty)
        {
        }

        public CustomAttributeFieldAttribute(string attributeName)
        {
            AttributeName = attributeName;
        }

        public string AttributeName { get; set; }

        /// <summary>
        /// true by default
        /// </summary>
        public bool AppendPrefix { get; set; } = true;
    }
}

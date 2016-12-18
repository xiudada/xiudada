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
        public CustomAttributeFieldAttribute(string attributeName)
        {
            if (String.IsNullOrEmpty(attributeName))
            {
                throw new ArgumentException("Attribute name should not be empty");
            }

            CustomeAttributeName = attributeName;
        }

        public string CustomeAttributeName { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public bool IsComplexType { get; set; }
    }
}

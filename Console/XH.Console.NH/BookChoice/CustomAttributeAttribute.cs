using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XH.Console.NH.BookChoice
{
    public class CustomAttributeAttribute : Attribute
    {
        public CustomAttributeAttribute()
        {

        }

        public bool IsComplexType { get; set; }

        public string Prefix { get; set; }
    }
}

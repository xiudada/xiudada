using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XH.Console.NH.BookChoice
{
    public class UserDto
    {
        public string Name { get; set; }

        [CustomAttributeField("ACT_Hobby")]
        public string Hobby { get; set; }

        [CustomAttribute]
        public TestClass Test { get; set; }
    }

    public class Location
    {
        [CustomAttributeField("Text_Region")]
        public string Region { get; set; }

        [CustomAttributeField("Text_City")]
        public string City { get; set; }

        [CustomAttributeField("Text_Address")]
        public string Address { get; set; }

        [CustomAttribute]
        public InnerTestClass SubTitle { get; set; }
    }

    public class InnerTestClass
    {
        [CustomAttributeField("SubTitle")]
        public string SubTitle { get; set; }
    }

    public class TestClass
    {
        [CustomAttribute(IsComplexType = true, Prefix = "ACT_")]
        public Location Location { get; set; }

        [CustomAttribute(IsComplexType = true, Prefix = "OPT_")]
        public Location OptionalLocation { get; set; }
    }
}

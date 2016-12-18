using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using log4net;
using NHibernate.Cfg;
using con = System.Console;
using XH.Console.NH.BookChoice;

namespace XH.Console.NH
{
    class Program
    {

        static void Main(string[] args)
        {
            TestCustomAttributeResolover();
            con.ReadKey();
        }

        static void Init()
        {
            log4net.Config.XmlConfigurator.Configure();
        }

        public static void TestCustomAttributeResolover()
        {
            UserDto user = new UserDto
            {
                Name = "qingluhuang",
                Hobby = "body building",
                Test = new TestClass
                {
                    Location = new Location
                    {
                        Region = "china",
                        City = "xiamen",
                        Address = "honglian",
                        SubTitle = new InnerTestClass
                        {
                            SubTitle = "test1"
                        }
                    },
                    OptionalLocation = new Location
                    {
                        Region = "china",
                        City = "sanming",
                        Address = "youxi",
                        SubTitle = new InnerTestClass
                        {
                            SubTitle = "optional sub title"
                        }
                    }
                }
            };

            ICustomAttributeResolver resolver = new CustomAttributeResolver();
            var customAttribute = resolver.ResolveCustomAttribute(user);
            int i = 0;
        }
    }



    public class Test
    {
        /// <summary>
        /// Created on
        /// </summary>
        public DateTime CreatedOn { get; set; }
    }
}

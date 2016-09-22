using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using log4net;
using NHibernate.Cfg;
using con = System.Console;

namespace XH.Console.NH
{
    class Program
    {

        static void Main(string[] args)
        {
            //Init();
            //Log log = new Log();
            //log.Do();
            DateTime time1 = DateTime.Now;
            DateTime time2 = DateTime.UtcNow;

            con.WriteLine("Time1:{0}", time1);
            con.WriteLine("Time1 - utc:{0}", time1.ToUniversalTime());
            con.WriteLine("Time2:{0}", time2);
            con.WriteLine("Time2 - utc:{0}", time2.ToLocalTime());
            con.WriteLine(time1 > time2);


            Test test = new Test();
            con.WriteLine(test.CreatedOn == default(DateTime));
            con.ReadKey();
        }

        static void Init()
        {
            log4net.Config.XmlConfigurator.Configure();
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

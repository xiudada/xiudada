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
            Init();
            Log log = new Log();
            log.Do();

            con.ReadKey();
        }

        static void Init()
        {
            log4net.Config.XmlConfigurator.Configure();
        }
    }
}

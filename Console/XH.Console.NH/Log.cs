using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using log4net;

namespace XH.Console.NH
{
    public class Log
    {
        private static ILog _log = LogManager.GetLogger(typeof(Log));

        public string Do()
        {
            _log.Debug("we're doing something");
            try
            {
                return System.IO.File.ReadAllText("test.txt");
            }
            catch
            {
                _log.Error("Somebody moved the file");
                throw;
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XH.Shared.Setting
{
    /// <summary>
    /// Site config
    /// </summary>
    public class SiteConfig
    {
        private static string googleApiKey = ConfigurationManager.AppSettings[AppConfigKeyNames.GoogleApiKey];

        /// <summary>
        /// Google api key
        /// </summary>
        public static string GoogleApiKey
        {
            get
            {
                return googleApiKey;
            }
        }
    }
}

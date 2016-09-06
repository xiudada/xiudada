using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using Owin;

namespace XH.APIs.WebAPI
{
    /// <summary>
    /// Owin config
    /// </summary>
    public class OwinConfig
    {
        /// <summary>
        /// Configure
        /// </summary>
        /// <param name="app"></param>
        public static void Configure(IAppBuilder app, HttpConfiguration config)
        {
            config.IncludeErrorDetailPolicy = IncludeErrorDetailPolicy.Always;
            WebApiConfig.Register(config);
        }
    }
}
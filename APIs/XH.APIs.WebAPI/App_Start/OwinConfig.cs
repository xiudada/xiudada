using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using Autofac.Integration.WebApi;
using Owin;
using XH.Infrastructure.Dependency;

namespace XH.APIs.WebAPI
{
    /// <summary>
    /// OWIN config
    /// </summary>
    public class OwinConfig
    {
        /// <summary>
        /// Configure
        /// </summary>
        /// <param name="app"></param>
        /// <param name="config"></param>
        public static void Configure(IAppBuilder app, HttpConfiguration config)
        {
            config.IncludeErrorDetailPolicy = IncludeErrorDetailPolicy.Always;
            WebApiConfig.Register(config);

            IocManager.Instance.Initialize();

            config.DependencyResolver = new AutofacWebApiDependencyResolver(IocManager.Instance.IocContainer);
            app.UseAutofacMiddleware(IocManager.Instance.IocContainer);
            app.UseAutofacWebApi(config);
            app.UseWebApi(config);
        }
    }
}
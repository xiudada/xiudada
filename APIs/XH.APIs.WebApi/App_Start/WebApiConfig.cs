using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Formatting;
using System.Web.Http;
using System.Web.Http.Cors;
using Newtonsoft.Json.Converters;

namespace XH.APIs.WebAPI
{
    /// <summary>
    /// Web api config
    /// </summary>
    public static class WebApiConfig
    {
        /// <summary>
        /// Register
        /// </summary>
        /// <param name="config"></param>
        public static void Register(HttpConfiguration config)
        {
            // Cors config
            //EnableCorsAttribute enableCorsAttribute = new EnableCorsAttribute("*", "*", "*", "*");
            //enableCorsAttribute.SupportsCredentials = true;
            //enableCorsAttribute.PreflightMaxAge = 60;
            //config.EnableCors(enableCorsAttribute);

            //// Config json format
            //// Configure default json formatter
            //JsonMediaTypeFormatter jsonFormatter = config.Formatters.JsonFormatter;
            //jsonFormatter.SerializerSettings.Converters.Add(new StringEnumConverter());

            // Route
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}

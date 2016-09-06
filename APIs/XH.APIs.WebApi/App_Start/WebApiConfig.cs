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
            //// Web API 配置和服务
            EnableCorsAttribute enableCorsAttribute = new EnableCorsAttribute("*", "*", "*", "*");
            enableCorsAttribute.SupportsCredentials = true;
            enableCorsAttribute.PreflightMaxAge = 60;
            config.EnableCors(enableCorsAttribute);

            // Format
            JsonMediaTypeFormatter jsonFormatter = config.Formatters.JsonFormatter;
            jsonFormatter.SerializerSettings.Converters.Add(new StringEnumConverter());

            // Web API 路由
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}

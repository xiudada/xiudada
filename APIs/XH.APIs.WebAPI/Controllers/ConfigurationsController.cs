using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Swashbuckle.Swagger.Annotations;
using XH.APIs.WebAPI.Models.Install;
using XH.Configurations;

namespace XH.APIs.WebAPI.Controllers
{
    [RoutePrefix("configurations")]
    public class ConfigurationsController : ApiControllerBase
    {
        private readonly IConfigurationProvider _configurationProvider;

        /// <summary>
        /// Configuration controller
        /// </summary>
        public ConfigurationsController(IConfigurationProvider configurationProvider)
        {
            _configurationProvider = configurationProvider;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("mongodb")]
        public IHttpActionResult UpdateMongoDBConfiguration(UpdateMongoDbConfigurationRequest request)
        {
            _configurationProvider.SaveConfiguration(new MongoDBConfig
            {
                ConnectionString = request.ConnectionString,
                DatabaseName = request.DatabaseName
            });

            return Ok();
        }


        [HttpGet]
        [Route("mongodb")]
        [SwaggerResponse(HttpStatusCode.OK, "Success", typeof(MongoDBConfig))]
        public IHttpActionResult GetMongoDBConfiguration()
        {
            var config = _configurationProvider.GetConfiguration<MongoDBConfig>();
            return Ok(config);
        }
    }
}

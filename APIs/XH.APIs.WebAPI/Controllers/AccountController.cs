using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Swashbuckle.Swagger.Annotations;

namespace XH.APIs.WebAPI.Controllers
{
    /// <summary>
    /// Test controller
    /// </summary>
    [RoutePrefix("account")]
    public class AccountController : ApiControllerBase
    {
        /// <summary>
        /// list users
        /// </summary>
        /// <returns></returns>
        [SwaggerResponse(HttpStatusCode.OK, "list users", typeof(String))]
        public IHttpActionResult ListUsers(ListUserQuery query)
        {
            return Ok();
        }

        /// <summary>
        /// Method
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("method")]
        [SwaggerResponse(200, "tttt", typeof(String))]
        public IHttpActionResult Method()
        {
            var model = new
            {
                Name = "huang",
                Aag = 26
            };

            return Ok(model);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace XH.APIs.WebAPI.Controllers
{
    [RoutePrefix("api/test")]
    public class TestController : ApiController
    {
        /// <summary>
        /// Method
        /// </summary>
        /// <returns></returns>
        public string Method()
        {
            return DateTime.Now.ToString();
        }
    }
}

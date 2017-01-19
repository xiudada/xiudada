using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace XH.Infrastructure.Web.Filters
{
    public class ValidateModelStateFilterAttribute : ActionFilterAttribute, IActionFilter
    {
        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            var modelState = actionContext.ModelState;
            var validationResult = new ValidationResult(modelState);

            if (validationResult.Success)
            {
                base.OnActionExecuting(actionContext);
            }
            else
            {
                var response = actionContext.Request.CreateResponse(System.Net.HttpStatusCode.BadRequest, validationResult);
                actionContext.Response = response;
            }
        }
    }
}

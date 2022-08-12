using Microsoft.AspNetCore.Mvc.Filters;
using System.Net;
using System.Web.Http.Controllers;

namespace Bounce.Api.Filter
{
   
    public class ValideModel : ActionFilterAttribute
    {
        //public override void OnActionExecuting(ActionExecutingContext actionContext)
        //{
        //    if (!actionContext.ModelState.IsValid)
        //    {

        //        actionContext.Response = actionContext.Request.CreateErrorResponse(
        //            HttpStatusCode.BadRequest, actionContext.ModelState);
        //    }
        //}
    }


}

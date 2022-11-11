using Bounce.DataTransferObject.Helpers.BaseResponse;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.Extensions.Caching.Memory;
using System.Net;
using System.Security.Claims;

namespace Bounce.Api.Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class BaseController : ControllerBase
    {
        private readonly IHttpContextAccessor httpContext;
        public ErrorResponse ErrorResponse;
        public long UserIdentity { get; set; }
        public BaseController(IHttpContextAccessor httpContext)
        {
            this.httpContext = httpContext;

            UserIdentity = GetLoggedUserId();
            if (UserIdentity == 0)
                ErrorResponse = new ErrorResponse
                {
                    ErrorMesaage = StatusCodes.Status401Unauthorized.ToString(),

                };




        }


        [NonAction]
        public long GetLoggedUserId()
        {
            var claimIdentity = httpContext.HttpContext.User.Identity as ClaimsIdentity;
            if (!claimIdentity.IsAuthenticated)
                return 0;
            var userId = claimIdentity.FindFirst("UserId") != null ? Convert.ToInt64(claimIdentity?.FindFirst("UserId").Value.ToString()) : 0;

            return userId;
        }


        protected new IActionResult Response(Response response)
        {
            var gdgdg = ModelState;

            if (response.StatusCode == 200)
                return Ok(new
                {
                    success = true,
                    data = response.Data,
                    Message = response.Message,
                    StatusCode = response.StatusCode,
                });


            if (response.StatusCode == StatusCodes.Status417ExpectationFailed)
                return StatusCode(StatusCodes.Status417ExpectationFailed, new
                {
                    success = false,
                    data = response.Data,
                    Message = response?.Message,
                    StatusCode = response?.StatusCode,
                });

            if (response.StatusCode == StatusCodes.Status400BadRequest)
                return BadRequest(new
                {
                    success = false,
                    data = response.Data,
                    Message = response?.Message,
                    StatusCode = response.StatusCode,
                });

            if (response.StatusCode == StatusCodes.Status401Unauthorized)
                return Unauthorized(new
                {
                    success = false,
                    data = response.Data,
                    Message = response?.Message,
                    StatusCode = response.StatusCode,
                });

            if (response.StatusCode == 404)
                return NotFound(new
                {
                    success = false,
                    data = response.Data,
                    Message = response?.Message,
                    StatusCode = response.StatusCode,
                });

            if (response.StatusCode == 409)
                return Conflict(new
                {
                    success = false,
                    data = response.Data,
                    Message = response?.Message,
                    StatusCode = response.StatusCode,
                });

            if (response.StatusCode == StatusCodes.Status500InternalServerError)
                return StatusCode((int)HttpStatusCode.InternalServerError, response);



            return StatusCode((int)response.StatusCode, response);

        }




    }
}

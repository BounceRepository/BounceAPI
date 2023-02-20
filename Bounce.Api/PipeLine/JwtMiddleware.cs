using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using System.Net;

namespace Bounce.Api.PipeLine
{
    public static class JwtTokenMiddleware
    {
        public static IApplicationBuilder UseJwtTokenMiddleware(this IApplicationBuilder app, string schema = JwtBearerDefaults.AuthenticationScheme)
        {



            WebRequest.DefaultWebProxy = new WebProxy("bounceserver", 80)
            {
                Credentials = new NetworkCredential("ifeanyi", "Ozougwu")
            };
           
            return app.Use(async (ctx, next) =>
            {
                if (ctx.User.Identity?.IsAuthenticated == true)
                {
                    var result = await ctx.AuthenticateAsync(schema);
                    if (result.Succeeded && result.Principal != null)
                    {
                        ctx.User = result.Principal;
                        

                    }

                }

                await next();
            });
        }
    }
}

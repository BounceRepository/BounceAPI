using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bounce_Application.Middleware
{
    //public static class JwtTokenMiddleware
    //{
    //    public static IApplicationBuilder UseJwtTokenMiddleware(this IApplicationBuilder app, string schema = JwtBearerDefaults.AuthenticationScheme)
    //    {
    //        return app.Use(async (ctx, next) =>
    //        {
    //            if (ctx.User.Identity?.IsAuthenticated != true)
    //            {
    //                var result = await ctx.AuthenticateAsync(schema);
    //                if (result.Succeeded && result.Principal != null)
    //                {
    //                    ctx.User = result.Principal;
    //                }
    //            }

    //            await next();
    //        });
    //    }
    //}
}

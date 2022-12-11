using Bounce_Domain.Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Bounce_Application.Utilies
{
    public class SessionManager
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IHttpContextAccessor _httpContext;
        private long UserId;
        
        public SessionManager(UserManager<ApplicationUser> userManager, IHttpContextAccessor httpContext)
        {
            _userManager = userManager;
            _httpContext = httpContext;
        }

        public ApplicationUser CurrentLogin
        {
            get
            {
               var userId =  GetLoggedUserId();
                if (userId == "Anonymous")
                {
                    return new ApplicationUser
                    {
                        Id = 1,
                        Email = "Bounce@gmail.com",
                        UserName = "BounceAdmin"
                    };
                }
                UserId = long.Parse(userId);
                return _userManager.Users.FirstOrDefault(x => x.Id == UserId);
            }
        }

        public long LoginUserId 
        { 
            get
            {
                var userId = GetLoggedUserId();
                if (userId == "Anonymous")
                {
                    return 1;
                }
                else
                {
                    return long.Parse(userId);
                }
            }
            
         }

        public string LoginUserEmail
        {
            get
            {
                var userId = GetLoggedUserId();
                if (userId == "Anonymous")
                {
                    return "Bounce@gmail.com";
                }
                else
                {
                    return  _userManager.Users.FirstOrDefault(x => x.Id == long.Parse(userId)).Email;
                }
            }

        }

        public string GetLoggedUserId()
        {
            var http = _httpContext?.HttpContext?.User;
           if(http != null)
            {
                var claimIdentity = http.Identity as ClaimsIdentity;
                if (!claimIdentity.IsAuthenticated)
                    return "Anonymous";
                return claimIdentity.FindFirst("UserId") != null ? claimIdentity?.FindFirst("UserId").Value.ToString() : "Anonymous";
    
            }
           return "Anonymous";
        }

    }
}

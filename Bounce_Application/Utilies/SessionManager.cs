using Bounce_Domain.Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
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
                UserId = Int64.Parse(_httpContext.HttpContext.Session.GetString("UserId"));
                return _userManager.Users.FirstOrDefault(x => x.Id == UserId);
            }
        }

    }
}

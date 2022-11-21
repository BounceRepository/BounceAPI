using Bounce_Application.Persistence.Interfaces.Helper;
using Bounce_DbOps.EF;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bounce.Job
{
    public class BaseJobScheduler
    {
        protected readonly IEmalService _EmailService;
        protected readonly IHttpContextAccessor contextAccessor;
        protected readonly IHostingEnvironment _hostingEnvironment;
        protected readonly BounceDbContext _context;

        public BaseJobScheduler(IEmalService emailService, IHttpContextAccessor contextAccessor, IHostingEnvironment hostingEnvironment, BounceDbContext context)
        {
            _EmailService = emailService;
            this.contextAccessor = contextAccessor;
            _hostingEnvironment = hostingEnvironment;
            _context = context;
        }
    }
}

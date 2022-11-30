using Hangfire;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bounce.Job
{
    public static class ScheduledServiceExtensions
    {
        public static IApplicationBuilder AddCronJob(this IApplicationBuilder  app, IJobScheduler jobScheduler)
        {     

            //RecurringJob.AddOrUpdate("CheckFreeTrial", () => jobScheduler.CheckFreeTrialAsync(), new CronExpressions(50).Minutes);
            RecurringJob.AddOrUpdate("ResendFailedEmailMessages", () => jobScheduler.ResendFaileMessages(), new CronExpressions(5).Minutes);

            return app;
        }
    }
}

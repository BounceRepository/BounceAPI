
using Cronos;
using Hangfire;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bounce.Job
{
    public class CronJobService : RecurringJobManager
    {
        private readonly IJobScheduler _jobScheduler;

        public CronJobService(IJobScheduler jobScheduler)
        {
            _jobScheduler = jobScheduler;
        }

        public async Task<bool> CheckFreeTrialTask() => await _jobScheduler.CheckFreeTrialAsync();
 

       
    }
}

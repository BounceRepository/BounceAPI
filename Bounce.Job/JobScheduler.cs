using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bounce.Job
{
    public class JobScheduler : IJobScheduler
    {
        public Task<bool> CheckFreeTrialAsync()
        {
            return Task.FromResult(true);
        }
    }
}

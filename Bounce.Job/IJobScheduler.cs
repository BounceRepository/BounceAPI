﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bounce.Job
{
    public interface IJobScheduler
    {
        Task<bool> CheckFreeTrialAsync();
    }
}
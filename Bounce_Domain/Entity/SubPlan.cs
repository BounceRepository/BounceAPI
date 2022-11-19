using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bounce_Domain.Entity
{
    public class SubPlan : BaseEntity
    {
        public string Title { get; set; }
        public long PLanId { get; set; }
        public int FreeTrialCount { get; set; }
        public int  NumberOfMeditation { get; set; }
        public double Cost { get; set; }
        public int TherapistCount { get; set; }
    }
}

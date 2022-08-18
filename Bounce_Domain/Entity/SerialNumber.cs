using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bounce_Domain.Entity
{
    public class SerialNumber : BaseEntity
    {
        public long PatientCount { get; set; }
        public long AdminCount { get; set; }
        public long TherapistCount { get; set; }
        public long ConsultationCount { get; set; }
    }
}

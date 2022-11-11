using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bounce_Domain.Entity
{
    public class TherapistHospitalInformation : BaseEntity
    {
        public string HospitalName { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Address { get; set; }
        public string LocalGovernment { get; set; }
        public string State { get; set; }
        public string? Email { get; set; }
        public long? TherapistId { get; set; }

        [ForeignKey(nameof(TherapistId))]
        public virtual ApplicationUser Therapist { get; set; }
    }
}

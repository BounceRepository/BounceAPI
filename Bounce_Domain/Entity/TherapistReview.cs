using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bounce_Domain.Entity
{
    public class TherapistReview :BaseEntity
    {
        public string ReviewComment { get; set; }
        public int RateCount  { get; set; }
        public DateTimeOffset Time { get; set; }
        public long? TherapistUserId { get; set; }
        [ForeignKey(nameof(TherapistUserId))]
        public virtual ApplicationUser Therapist { get; set; }
        public long? PatientUserId { get; set; }

    }
}

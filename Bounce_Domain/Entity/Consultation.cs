using Bounce_Domain.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Bounce_Domain.Entity
{
    public class Consultation : BaseEntity
    {
        public long PatientId { get; set; }
        [ForeignKey(nameof(PatientId))]
        [JsonIgnore]
        public virtual ApplicationUser Patient { get; set; }

        public long TherapistId { get; set; }
        [ForeignKey(nameof(TherapistId))]
        [JsonIgnore]
        public virtual ApplicationUser Therapist { get; set; }

        public long ConsultaionCategoryId { get; set; }
        [ForeignKey(nameof(TherapistId))]
        [JsonIgnore]
        public virtual ConsultaionCategory ConsultaionCategory { get; set; }
        public double Price { get; set; }
        public double TotalAMount { get; set; }

        public DateTime ConsultaionDate { get; set; }
        public bool Active { get; set; }
        public double Duration { get; set; }
        public SessionType? SessionType { get; set; }
        public int Rating { get; set; }
    }
}

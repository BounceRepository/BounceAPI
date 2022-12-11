using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Bounce_Domain.Entity
{
    public class AppointmentRequest : BaseEntity
    {
        public long? PatientId { get; set; }
        [ForeignKey(nameof(PatientId))]
        [JsonIgnore]
        public virtual ApplicationUser Patient { get; set; }

        public long? TherapistId { get; set; }
        [ForeignKey(nameof(TherapistId))]
        [JsonIgnore]
        public virtual ApplicationUser Therapist { get; set; }
        public string TrxRef { get; set; }

        [Display(Name = "Start Time")]
        public string AgeRange { get; set; }
        public double Price { get; set; }
        public double TotalAMount { get; set; }
        public DateTimeOffset?  StartTime{ get; set; }

        public DateTimeOffset? EndTime { get; set; }

        public DateTime? Date { get; set; }
        public DateTime AvailableTime { get; set; }
        [Required]
        public string PaymentType { get; set; }
        [Required]
        public string AppointmentType { get; set; }
        [Required]
        public string ProblemDecription { get; set; }
        public bool IsPaymentCompleted { get; set; }
    }
}

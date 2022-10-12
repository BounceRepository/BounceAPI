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
    public class Appointment : BaseEntity
    {
        public long? AppointmentRequestId { get; set; }
        [ForeignKey(nameof(AppointmentRequestId))]
        [JsonIgnore]
        public virtual AppointmentRequest AppointmentRequest { get; set; }
        public DateTime? AppointmentStartTime { get; set; }
        public DateTime? AppointmentEndTime { get; set; }
        public int SpendTimeInMunites { get; set; }
        public bool Active { get; set; }
        public double Duration { get; set; }
        public AppointStatus? Status { get; set; }
        public SessionType? SessionType { get; set; }
        public int Rating { get; set; }

    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bounce_Domain.Entity
{
    public class Prescription : BaseEntity
    {

        public long? AppointmentRequestId { get; set; }

        [ForeignKey("AppointmentRequestId")]
        public virtual AppointmentRequest AppointmentRequest { get; set; }
        public string? Drug { get; set; }
        public string? Dosage { get; set; }

        public string? PrescriptionText { get; set; }
        public string? File { get; set; }
    }
}

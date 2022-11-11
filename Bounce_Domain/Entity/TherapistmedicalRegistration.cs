using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bounce_Domain.Entity
{
    public class TherapistmedicalRegistration: BaseEntity
    {
        public string MedicalCouncilName { get; set; }
        public string RegistrationNumber { get; set; }
        public string RegistrationCertificateFilePath { get; set; }
        public string DegreeCertificateFilePath { get; set; }
        public string Hospital { get; set; }
        public long? TherapistId { get; set; }
        [ForeignKey(nameof(TherapistId))]
        public virtual ApplicationUser Therapist { get; set; }
    }
}

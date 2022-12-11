using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bounce.DataTransferObject.DTO.Patient
{
    public class AppointmentDto
    {

        [Required]
        public long TherapistId { get; set; }
        public double Price { get; set; }
        public double TotalAMount { get; set; }

        [Required]
        public string StartTime { get; set; }
        public DateTime AvailableTime { get; set; }
        [Required]
        public string PaymentType { get; set; }
        [Required]
        public string AppointmentType { get; set; }
        [Required]
        public string ProblemDecription { get; set; }
        public DateTime? Date { get; set; }
    }
}

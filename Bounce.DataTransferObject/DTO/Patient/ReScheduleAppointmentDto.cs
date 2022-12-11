using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bounce.DataTransferObject.DTO.Patient
{
    public class ReScheduleAppointmentDto
    {
        [Required]
        public long SessionId { get; set; }

        public string StartTime { get; set; }

        public DateTimeOffset Date { get; set; }

      
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bounce.DataTransferObject.DTO.Therapist
{
    public class SchedulersItmesDto
    {
        public string PatientName { get; set; }
        public string Status { get; set; }
        public string StartTime { get; set; }
        public DateTime Time { get; set; }
    }

    public class SchedulersDto
    {
        public DateTime Date { get; set; }
        public List<SchedulersItmesDto> Appointments { get; set; }
    }
}

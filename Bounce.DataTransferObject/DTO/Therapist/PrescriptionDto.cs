using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bounce.DataTransferObject.DTO.Therapist
{
    public class PrescriptionDto
    {

        public long RevceieverId { get; set; }
        public string? Drug { get; set; }
        public string? Dosage { get; set; }
        public string? Prescription { get; set; }
        public IFormFile? File { get; set; }
        public long AppointmentId { get; set; }



    }
}

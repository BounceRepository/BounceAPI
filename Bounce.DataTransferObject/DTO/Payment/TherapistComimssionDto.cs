using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bounce.DataTransferObject.DTO.Payment
{
    public class TherapistComimssionDto
    {
        public long TherapistId { get; set; }
        public string Description { get; set; }
        public double Amount { get; set; }
    }
}

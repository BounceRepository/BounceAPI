using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bounce.DataTransferObject.DTO.Patient
{
    public class PlanDto
    {
        public long Id { get; set; }
        public string?  Name { get; set; }
        public double Cost { get; set; }
        public int Duration { get; set; }

    
    }
}

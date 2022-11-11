using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bounce.DataTransferObject.DTO.Patient
{
    public class GetAllPlansDto
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public int DailyMeditation { get; set; }
        public int FreeDaysTrialCount { get; set; }
        public int Therapist { get; set; }
        public double Cost { get; set; }
    }
}

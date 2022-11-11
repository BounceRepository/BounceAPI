using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bounce.DataTransferObject.DTO.Admin
{
    public class DashBoardStatisticsDto
    {
        public long Patients { get; set; }
        public long Therapist { get; set; }
        public long AllConsultaions { get; set; }
    }
}

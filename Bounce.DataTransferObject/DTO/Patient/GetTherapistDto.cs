using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bounce.DataTransferObject.DTO.Patient
{
    public class GetTherapistDto
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Specialization { get; set; }
        public int Ratings { get; set; }
        public string YearsExperience { get; set; }
        public string About { get; set; }
        public string HoursWorking { get; set; }
        public string PhoneNUmber { get; set; }
        public string PicturePath { get; set; }
        public int Revew { get; set; }


    }
}

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
        public string FirstName { get; set; }
        public string Descipline { get; set; }
        public string LastName { get; set; }
        public List<string> Specialization { get; set; }
        public int Ratings { get; set; }
        public string YearsExperience { get; set; }
        public string About { get; set; }
        public string ListofDays { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }
        public string PhoneNUmber { get; set; }
        public string PicturePath { get; set; }
        public int Revew { get; set; }


    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bounce.DataTransferObject.DTO.Therapist
{
    public class TherapistProfileResponseDto : TherapistBaseProfileDto
    {
        public string ProfilePicture { get; set; }
        public double ServiceChargePerHoure { get; set; }
        public int NumberOfPatient { get; set; }
        public int ReviewCount { get; set; }
        public decimal ReviewRatio { get; set; }
    }

   public class TherapistProfileDetailDto : TherapistProfileResponseDto
   {
        public string EmailAddress { get; set; }
   }

}

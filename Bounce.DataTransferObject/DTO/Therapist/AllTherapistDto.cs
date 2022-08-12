using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bounce.DataTransferObject.DTO.Therapist
{
    public class AllTherapistDto
    {
        public long UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PicturePath { get; set; }
    }
}

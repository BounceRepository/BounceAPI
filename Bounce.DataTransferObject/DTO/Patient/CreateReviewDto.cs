using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bounce.DataTransferObject.DTO.Patient
{
    public class CreateReviewDto
    {
        public string ReviewComment { get; set; }
        public int ReviewStarCount { get; set; }
        public DateTimeOffset Time { get; set; }
        public long TherapistUserId { get; set; }

    }
}

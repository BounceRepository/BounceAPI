using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Bounce_Domain.Entity
{
    public class TherapistAccessment : BaseEntity
    {
        public long? TherapistId { get; set; }
        [ForeignKey(nameof(TherapistId))]
        [JsonIgnore]
        public virtual ApplicationUser Therapist { get; set; }
        public int TotalPassed { get; set; }
        public int TotalFailed { get; set; }
        public int TotalScore { get; set; }
        public int TotalQuestion { get; set; }
        public string AnsweredQuestionIds { get; set; }
    }
}

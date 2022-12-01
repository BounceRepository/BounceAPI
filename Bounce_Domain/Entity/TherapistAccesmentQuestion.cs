using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bounce_Domain.Entity
{
    public class TherapistAccesmentQuestion : BaseEntity
    {
        public string Question { get; set; }
        public string OptionA { get; set; }
        public string OptionB { get; set; }
        public string OptionC { get; set; }
        public string OptionD { get; set; }
        public string CorrectAnswer { get; set; }
        public long?  CreatedById{ get; set; }
        [ForeignKey(nameof(CreatedById))]
        public virtual ApplicationUser CreatedBy { get; set; }
    }
}

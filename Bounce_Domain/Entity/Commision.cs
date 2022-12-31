using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bounce_Domain.Entity
{
    public class Commision : BaseEntity
    {
        public double Amount { get; set; }

        public string TransactionRef { get; set; }
        public string Decription { get; set; }
        public long TherapistId { get; set; }

        [ForeignKey(nameof(TherapistId))]
        public virtual ApplicationUser Therapist { get; set; }
    }
}

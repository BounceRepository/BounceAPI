using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bounce_Domain.Entity
{
    public class Subscription : BaseEntity
    {
        public long PlanId { get; set; }
        [ForeignKey(nameof(PlanId))]
        public virtual Plan Plan { get; set; }
        public long UserId { get; set; }
        [ForeignKey(nameof(UserId))]
        public virtual ApplicationUser User { get; set; }
        public int Duration { get; set; }
        public DateTime? ExpiryDate { get; set; }
    }
}

using Bounce_Domain.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bounce_Domain.Entity
{
    public class PaymentRequest: BaseEntity
    {

        public string? PaymentRequestId { get; set; }
        public long? UserId { get; set; }
        [ForeignKey("UserId")]
        public virtual ApplicationUser User { get; set; }

        public long? SubId { get; set; }
        public long? SubPlanId { get; set; }
        [ForeignKey("SubId")]
        public virtual SubPlan SubPlan { get; set; }
        public double Amount { get; set; }
        public string? PaymentDecription { get; set; }
        public DateTime CompletedTime { get; set; }
        public string? StatusCode { get; set; }
        public PaymentType? PaymentType { get; set; }
        public string? IssuerTransRef { get; set; }
        public bool Completed { get; set; }

    }
}

using Bounce_Domain.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bounce_Domain.Entity
{
    public class Transaction : BaseEntity
    {
        public long? RequestId { get; set; }
        [ForeignKey(nameof(RequestId))]
        public PaymentRequest Request { get; set; }
        public TransactionType? TransactionType { get; set; }
        public string Decription { get; set; }
    }
}

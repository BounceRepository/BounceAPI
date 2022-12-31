using Bounce_Domain.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bounce_Domain.Entity
{
    public class PoolTransaction : BaseEntity
    {
        public string? TransactionRef { get; set; }
        public double Amount { get; set; }
        public long? TransactionInitiatedByUserId { get; set; }
        public string PoolType { get; set; }
        public PoolTransactionType? TransactionType { get; set; }
        public string? Decsription { get; set; }
        public string? Status { get; set; }
        public long TransactionCompletedByUserId { get; set; }
        [ForeignKey("TransactionCompletedByUserId")]
        public virtual ApplicationUser User { get; set; }
        public DateTime Time { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bounce_Domain.Entity
{
    public class BankAccountDetails : BaseEntity
    {
        public string?  AccountName { get; set; }
        public string? AccountNumber { get; set; }
        public string? AccountType { get; set; }
        public string? BankName { get; set; }
        public long TherapistId { get; set; }

        [ForeignKey(nameof(TherapistId))]
        public virtual ApplicationUser Therapist { get; set; }
    }
}

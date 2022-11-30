using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bounce_Domain.Entity
{
    public class AuditTrail
    {
        [Key]
        public long Id { get; set; }
        public long? UserId { get; set; }
        [ForeignKey(nameof(UserId))]
        public virtual ApplicationUser PerformedByUser { get; set; }
        public string ActionDescription { get; set; }
        public string IPAddress { get; set; }
        public DateTimeOffset DateCreated { get; set; }
        public DateTimeOffset DateOffsetCreated { get; set; }

    }
}

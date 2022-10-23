using Bounce_Domain.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Bounce_Domain.Entity
{
    public class WalletRequest : BaseEntity
    {
        public double Amount { get; set; }
        public long UserId { get; set; }
        [ForeignKey(nameof(UserId))]
        [JsonIgnore]
        public virtual ApplicationUser User { get; set; }
        public string? Refxn { get; set; }
        public string? IsCompleted { get; set; }
        public string? Descrription { get; set; }
        public DateTime Time { get; set; }
        public WalletRequestType RequestType { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Bounce_Domain.Entity
{
    public class Wallet : BaseEntity
    {
        public long UserId { get; set; }
        [ForeignKey(nameof(UserId))]
        [JsonIgnore]
        public virtual ApplicationUser User { get; set; }

        public double Balance { get; set; }
        public double ReferalBonus { get; set; }
        public double AvailableBalance { get; set; }
        public double Pendingdebit { get; set; }

    }
}

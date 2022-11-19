using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Bounce_Domain.Entity
{
    public class Chat : BaseEntity
    {
        public long SenderId { get; set; }
        [ForeignKey(nameof(SenderId))]
        [JsonIgnore]
        public virtual ApplicationUser Sender { get; set; }

        public long ReceieverId { get; set; }
        [ForeignKey(nameof(ReceieverId))]
        [JsonIgnore]
        public virtual ApplicationUser Receiever { get; set; }

        public string? Message { get; set; }
        public string? Files { get; set; }

        public bool HasFile { get; set; }
        public string? MessageRefx { get; set; }
        public string? Aux { get; set; }

    }
}

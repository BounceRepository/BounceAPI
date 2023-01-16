using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Bounce_Domain.Entity
{
    public class AlgoraChannel : BaseEntity
    {
        public string? ChannelToken { get; set; }
        public string? ChannelName { get; set; }
        public long? AppointmentRequestId{ get; set; }

        [ForeignKey(nameof(AppointmentRequestId))]
        [JsonIgnore]
        public virtual AppointmentRequest AppointmentRequest { get; set; }
        public DateTime? CompletionTime { get; set; }
    }
}

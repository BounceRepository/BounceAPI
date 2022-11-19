using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bounce.DataTransferObject.DTO.Notification
{
    public class AllMessagesDto
    {
        public long ChatId { get; set; }
        public string? Message { get; set; }
        public DateTimeOffset? Time { get; set; }
        public string MessageType { get; set; }
        public long ReceieverId { get; set; }
        public string ReceieverUserName { get; set; }
        public long SenderId { get; set; }
        public string SenderUserName { get; set; }
        public string[] Files { get; set; }
        public bool HasFile { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bounce.DataTransferObject.DTO.Notification
{
    public class ChatHubDto
    {
        public long RevceieverId { get; set; }
        public string Message { get; set; }
        public string[] FilePaths { get; set; }
        public DateTimeOffset Time { get; set; }

    }

    public class RecievedMessageDto
    {
        public long SenderId { get; set; }
        public int SenderName { get; set; }

        public long RevceieverId { get; set; }
        public long RevceieverName { get; set; }
        public string Message { get; set; }
        public string[] FilePaths { get; set; }
        public DateTimeOffset Time { get; set; }

    }
}

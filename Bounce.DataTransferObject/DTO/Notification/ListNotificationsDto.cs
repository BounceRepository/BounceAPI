using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bounce.DataTransferObject.DTO.Notification
{
    public class ListNotificationsDto
    {
        
        public long NotificationId { get; set; }
        public string Message { get; set; }
        public string Title { get; set; }
        public DateTime Time { get; set; }
        public bool IsNewNotification { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bounce.DataTransferObject.DTO.Notification
{
    public class PushNotificationDto
    {
       
       
        public string Message { get; set; }
        public string Title { get; set; }
        public string Topic { get; set; }
        public string TrxRef { get; set; }

    }
}

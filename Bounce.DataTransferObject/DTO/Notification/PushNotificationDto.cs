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
        [Required]
        public long UserId { get; set; }
        [Required]
        public string Message { get; set; }
        [Required]
        public string Title { get; set; }

    }
}

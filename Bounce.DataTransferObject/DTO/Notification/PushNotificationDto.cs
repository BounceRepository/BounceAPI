﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bounce.DataTransferObject.DTO.Notification
{
    public class PushNotificationDto
    {

        public object User { get; set; }
        public string Message { get; set; }
        public string Title { get; set; }
        public string Topic { get; set; }
        public string TrxRef { get; set; }
        public long userId { get; set; }

    }
}

﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Bounce_Domain.Entity
{
    //public class Notifications : BaseEntity
    //{
    //    public Notifications()
    //    {
    //        IsNewNotication = true;
    //    }
    //    public long UserId { get; set; }
    //    [ForeignKey(nameof(UserId))]
    //    [JsonIgnore]
    //    public virtual ApplicationUser User { get; set; }
    //    public string Message { get; set; }
    //    public string Title { get; set; }
    //    public bool IsNewNotication { get; set; }
    //    public string? NotificationRef { get; set; }

    //}


    public class NotificationModel : BaseEntity
    {
        public NotificationModel()
        {
            IsNewNotication = true;
        }
        public long UserId { get; set; }
        [ForeignKey(nameof(UserId))]
        [JsonIgnore]
        public virtual ApplicationUser User { get; set; }
        public string Message { get; set; }
        public string Title { get; set; }
        public bool IsNewNotication { get; set; }
        public string? NotificationRef { get; set; }

    }
}

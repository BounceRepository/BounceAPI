﻿using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bounce.DataTransferObject.DTO.Notification
{
    public class SendMessageDto
    {
      
        [Required]
        public long ReceieverId { get; set; }
        [Required]
        public string? Message { get; set; }
        public IFormFileCollection? Files { get; set; }
        public DateTimeOffset Time { get; set; }

    }
}
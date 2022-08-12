﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bounce_Application.DTO.ServiceModel
{
    public class SmtpConfiguration
    {
        public string Host { get; set; }
        public int Post { get; set; }
        public string Password { get; set; }
        public string EmailAddress { get; set; }
        public bool EnableSSl { get; set; }
    }
}

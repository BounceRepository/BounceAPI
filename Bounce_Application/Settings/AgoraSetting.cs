using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bounce_Application.Settings
{
    public class AgoraSetting
    {
        public string appId { get; set; }
        public string appCertificate { get; set; }
        public string channelName { get; set; }
        public string uid { get; set; }
        public string userAccount { get; set; }
        public int expirationTimeInSeconds { get; set; }
    }
}

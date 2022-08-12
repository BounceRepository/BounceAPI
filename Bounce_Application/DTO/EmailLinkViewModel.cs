using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bounce_Application.DTO
{
    public class EmailLinkViewModel
    {
        public string Key { get; set; }
        public ConfrimationStatus Status { get; set; }
    }

    public enum ConfrimationStatus
    {
        Confirmed,
        InvalidLink,
        LinkExpired,
        Exception,
        Failed,
        InvaidUser,
        FailedLink,
        EmailConfirmedlreday
    }
}

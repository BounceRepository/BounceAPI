using Bounce_Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bounce.Services.Events.Args
{
    public class WalletTopEventArgs : EventArgs
    {
        public long UserId { get; set; }
        public int Status { get; set; }
        public string Email { get; set; }
        public string TranxRef { get; set; }
        public string Username { get; set; }
        public WalletRequest Request { get; set; }
    }
}

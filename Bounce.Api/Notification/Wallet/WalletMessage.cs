using Bounce.DataTransferObject.Helpers.BaseResponse;
using Bounce_Application.Persistence.Interfaces.Payment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bounce.Api.Notification.Wallet
{
    public class WalletMessage
    {
        public string TrnxRef { get; set; }
        public object _paymentServices { get; set; }
    }
}

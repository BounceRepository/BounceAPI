using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bounce.DataTransferObject.Helpers
{
    public  static class AdminConstants
    {
        public static string FullDate = "ddd, dd MMM yyyy H:mm tt";
        public static string WalletTopUp = "TOPUP";
        public static string WalletPayment = "PAYMENT";

    }
    
    public static class AdminStatus
    {
        public static string Success = "00";
        public static string Failed = "01";
    }
}

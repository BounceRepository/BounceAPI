using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bounce.DataTransferObject.DTO.Payment
{
    public class FlutterWavePaymentResponse
    {
        public string status { get; set; }
        public string chargecode { get; set; }
        public string TxRef { get; set; }
        public decimal amount { get; set; }
    }
}

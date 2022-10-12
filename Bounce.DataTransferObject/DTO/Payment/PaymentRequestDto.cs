using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bounce.DataTransferObject.DTO.Payment
{
    public class PaymentRequestDto
    {
        public string PaymentType { get; set; }
        public double Amount { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bounce.DataTransferObject.DTO.Payment
{
    public class TransactionHistoryDto
    {
        public string TransactionId { get; set; }
        public decimal Amount { get; set; }
        //public DateTime Time { get; set; }
        public string TransactionType { get; set; }
        public string Message { get; set; }
        public string Title { get; set; }
        public DateTime Time { get; set; }
        public string TimeToString { get; set; }

    }
}

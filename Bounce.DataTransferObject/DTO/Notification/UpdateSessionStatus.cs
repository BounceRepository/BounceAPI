using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bounce.DataTransferObject.DTO.Notification
{
    public class UpdateSessionStatus
    {
        public long AppointmentRequestId { get; set; }
        public bool IsStart { get; set; }
    }
}

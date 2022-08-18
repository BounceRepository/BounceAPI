using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bounce.DataTransferObject.Helpers.BaseResponse
{
    public class Response
    {
        public Object Data { get; set; }
        public int StatusCode { get; set; }
        public string Message { get; set; }
      
    }
}

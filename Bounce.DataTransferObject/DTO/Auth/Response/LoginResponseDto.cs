using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bounce.DataTransferObject.DTO.Auth.Response
{
    public class LoginResponseDto
    {
        public string UserName { get; set; }
        public string Token { get; set; }
        public string Message { get; set; }
    }
}

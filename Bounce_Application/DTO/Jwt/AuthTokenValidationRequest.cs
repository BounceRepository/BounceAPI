using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bounce_Application.DTO.Jwt
{
	public class AuthTokenValidationRequest
	{
        public string AuthTokenHash { get; set; }
        public string AuthTokenSalt { get; set; }
        public string RefreshTokenSalt { get; set; }
        public string RefreshTokenHash { get; set; }
        public string AuthToken { get; set; }
        public string RefreshToken { get; set; }
    }
}

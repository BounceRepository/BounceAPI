using Bounce_Application.DTO.Jwt;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Bounce_Application.Persistence.Interfaces.Auth.Jwt
{
	public interface IJwtFactory
	{
		Task<string> GenerateEncodedToken(string userName, ClaimsIdentity identity);
		ClaimsIdentity GenerateClaimsIdentity(string userName, string id);
		bool ValidateAuthToken(AuthTokenValidationRequest request);
	}
}

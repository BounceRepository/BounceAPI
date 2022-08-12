using Bounce_Application.Cryptography.Hash;
using Bounce_Application.DTO.Jwt;
using Bounce_Application.DTO.Jwt.Constant;
using Bounce_Application.Persistence.Interfaces.Auth.Jwt;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Bounce.Services.Implementation.Jwt
{
	public class JwtFactory : IJwtFactory
	{
		private readonly JwtIssuerOptions jwtIssuerOptions;
		private readonly ICryptographyService cryptographyService;

		public JwtFactory(IOptions<JwtIssuerOptions> jwtIssuerOptions, ICryptographyService cryptographyService)
		{
			this.jwtIssuerOptions = jwtIssuerOptions.Value;
			ThrowIfInvalidOptions(jwtIssuerOptions.Value);
			this.cryptographyService = cryptographyService;
		}

		public ClaimsIdentity GenerateClaimsIdentity(string userName, string id)
		{
			return new ClaimsIdentity(new GenericIdentity(userName, "Token"), new[]
			{
				new Claim(JwtClaimIdentifiers.Id, id),
				new Claim(JwtClaimIdentifiers.Role, JwtClaimIdentifiers.ApiAccess)
			});
		}

		public async Task<string> GenerateEncodedToken(string userName, ClaimsIdentity identity)
		{
			var claims = new[]
		   {
				 new Claim(JwtRegisteredClaimNames.Sub, userName),
				 new Claim(JwtRegisteredClaimNames.Jti, await jwtIssuerOptions.JtiGenerator()),
				 new Claim(JwtRegisteredClaimNames.Iat, ToUnixEpochDate(jwtIssuerOptions.IssuedAt).ToString(), ClaimValueTypes.Integer64),
				 identity.FindFirst(JwtClaimIdentifiers.Role),
				 identity.FindFirst(JwtClaimIdentifiers.Id)
			};

			var jwt = new JwtSecurityToken(
				issuer: jwtIssuerOptions.Issuer,
				audience: jwtIssuerOptions.Audience,
				claims: claims,
				notBefore: jwtIssuerOptions.NotBefore,
				expires: jwtIssuerOptions.Expiration,
				signingCredentials: jwtIssuerOptions.SigningCredentials);

			var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);
			return encodedJwt;
		}

		public bool ValidateAuthToken(AuthTokenValidationRequest request)
		{
			bool validateAuthToken = cryptographyService.ValidateHash(request.AuthToken, request.AuthTokenSalt, request.AuthTokenHash);
			bool validateRefreshToken = cryptographyService.ValidateHash(request.RefreshToken, request.RefreshTokenSalt, request.RefreshTokenHash);

			if (validateAuthToken && validateRefreshToken)
				return true;

			return false;
		}

		private static long ToUnixEpochDate(DateTime date)
		  => (long)Math.Round((date.ToUniversalTime() -
							   new DateTimeOffset(1970, 1, 1, 0, 0, 0, TimeSpan.Zero))
							  .TotalSeconds);

		// ReSharper disable once ParameterOnlyUsedForPreconditionCheck.Local
		private static void ThrowIfInvalidOptions(JwtIssuerOptions options)
		{
			if (options == null) throw new ArgumentNullException(nameof(options));

			if (options.ValidFor <= TimeSpan.Zero)
			{
				throw new ArgumentException("Must be a non-zero TimeSpan.", nameof(JwtIssuerOptions.ValidFor));
			}

			if (options.SigningCredentials == null)
			{
				throw new ArgumentNullException(nameof(JwtIssuerOptions.SigningCredentials));
			}

			if (options.JtiGenerator == null)
			{
				throw new ArgumentNullException(nameof(JwtIssuerOptions.JtiGenerator));
			}
		}
	}
}

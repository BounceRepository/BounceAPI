using Bounce.DataTransferObject.DTO.Auth;
using Bounce.DataTransferObject.Helpers.BaseResponse;
using Bounce_Application.DTO.Auth;
using Bounce_Application.Persistence.Interfaces.Auth;
using Bounce_Applucation.DTO.Auth;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bounce_Application.DTO;
using Bounce_Application.Utilies;
using Bounce_Application.Persistence.Interfaces.Helper;
using Bounce.DataTransferObject.DTO.Auth.Response;
using Bounce_Application.Persistence.Interfaces.Auth.Jwt;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using Bounce_Application.Cryptography.Hash;
using Bounce_Domain.Entity;

namespace Bounce.Services.Implementation.Services.Auth
{
	public class AuthenticationServivce : IAuthenticationServivce
	{

		private readonly UserManager<ApplicationUser> _userManager;
		private readonly SignInManager<ApplicationUser> signInManager;
		private readonly RoleManager<ApplicationRole> _roleManager;
		private readonly IConfiguration _configuration;
		private readonly IHostingEnvironment _hostingEnvironment;
		private readonly IEmalService _EmailService;
		private readonly ICryptographyService _cryptographyService ;
		private readonly IHttpContextAccessor contextAccessor;
		private static string EmailConfrimationUrl = "Bounce/ConfirmEmail";
		public string rootPath { get; set; }


        public AuthenticationServivce(UserManager<ApplicationUser> userManager, RoleManager<ApplicationRole> roleManager, IConfiguration configuration, IHostingEnvironment hostingEnvironment,
            IEmalService emailService, ICryptographyService cryptographyService, SignInManager<ApplicationUser> signInManager, IHttpContextAccessor contextAccessor)
        {

            _userManager = userManager;
            _roleManager = roleManager;
            _configuration = configuration;
            _hostingEnvironment = hostingEnvironment;
            rootPath = _hostingEnvironment.ContentRootPath;
            _EmailService = emailService;
            _cryptographyService = cryptographyService;
            this.signInManager = signInManager;
            this.contextAccessor = contextAccessor;
        }



        public async Task<Response> RegisterAdminUser(RegisterModel registerModel)
		{
			try
			{
				var userExists = await _userManager.FindByNameAsync(registerModel.Username);
				if (userExists != null)
					return new Response
					{
						StatusCode = StatusCodes.Status409Conflict,
						Data = null,
						Error = new ErrorResponse
						{
							ErrorMesaage = "User Already Exist"
						}
					};
				ApplicationUser user = new()
				{
					Email = registerModel.Email,
					SecurityStamp = Guid.NewGuid().ToString(),
					UserName = registerModel.Username
				};
				var result = await _userManager.CreateAsync(user, registerModel.Password);

				if (!result.Succeeded)
				{
					string errorMessage = "";
					if (result.Errors.Count() > 0)
					{
						var errors = result.Errors;
						foreach (var error in errors)
						{
							errorMessage += $"{error.Description} \n";
						}
						return new Response
						{
							StatusCode = StatusCodes.Status400BadRequest,
							Error = new ErrorResponse { ErrorMesaage = errorMessage }
						};
					}
					else
						return new Response { StatusCode = StatusCodes.Status500InternalServerError, Error = new ErrorResponse { ErrorMesaage = "Pls try again" } };

				}

				if (!await _roleManager.RoleExistsAsync(UserRoles.Administrator))
					await _roleManager.CreateAsync(new ApplicationRole { Name = UserRoles.Administrator });

				var role = await _userManager.AddToRoleAsync(user, UserRoles.Administrator);


				var time = DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss");
				var delimiter = $"{user.Email}^{time}";
				var email = _cryptographyService.Base64Encode(delimiter);

				var token = await _userManager.GenerateEmailConfirmationTokenAsync(user);


				var scheme = contextAccessor.HttpContext.Request.Scheme;
				var host = contextAccessor.HttpContext.Request.Host.Value;

				var fileurl = $"{scheme}://{host}/{EmailConfrimationUrl}";
				var baseUrl = $"{fileurl}?token={token}&email={email}";

				var emailRequest = new EmailRequest
				{
					To = registerModel?.Email,
					Body = EmailFormatter.FormatEmaiConfimation(baseUrl, rootPath),
					Subject = "Email Confirmation"
				};

				await _EmailService.SendMail(emailRequest);

				return new Response
				{
					StatusCode = StatusCodes.Status200OK,
					Data = new RegistrationResponseDto
					{
						Token = token,
						Message = "user created successfully"
					}
				};



			}
			catch (Exception ex)
			{

				//throw ex;
				return new Response
				{
					StatusCode = StatusCodes.Status500InternalServerError,
					Data = null,
					Error = new ErrorResponse
					{
						ErrorMesaage = "Internal server error occured"
					}
				};

			}
		}

		public async Task<Response> RegisterTherapist(RegisterModel registerModel)
		{
			try
			{
				var userExists = await _userManager.FindByNameAsync(registerModel.Username);
				if (userExists != null)
					return new Response
					{
						StatusCode = StatusCodes.Status400BadRequest,
						Data = null,
						Message = "User Already Exist"
					};
				ApplicationUser user = new()
				{
					Email = registerModel.Email,
					SecurityStamp = Guid.NewGuid().ToString(),
					UserName = registerModel.Username
				};
				var result = await _userManager.CreateAsync(user, registerModel.Password);

				if (!result.Succeeded)
				{
					string errorMessage = "";
					if (result.Errors.Count() > 0)
					{
						var errors = result.Errors;
						foreach (var error in errors)
						{
							errorMessage += $"{error.Description} \n";
						}
						return new Response
						{
							StatusCode = StatusCodes.Status400BadRequest,
							Error = new ErrorResponse { ErrorMesaage = errorMessage }
						};
					}
					else
						return new Response { StatusCode = StatusCodes.Status500InternalServerError, Error = new ErrorResponse { ErrorMesaage = "Pls try again" } };

				}

				if (!await _roleManager.RoleExistsAsync(UserRoles.Therapist))
					await _roleManager.CreateAsync(new ApplicationRole { Name = UserRoles.Therapist });

				var role = await _userManager.AddToRoleAsync(user, UserRoles.Therapist);


				var time = DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss");
				var delimiter = $"{user.Email}^{time}";
				var email = _cryptographyService.Base64Encode(delimiter);

				var token = await _userManager.GenerateEmailConfirmationTokenAsync(user);

				var scheme = contextAccessor.HttpContext.Request.Scheme;
				var host = contextAccessor.HttpContext.Request.Host.Value;

				var fileurl = $"{scheme}://{host}/{EmailConfrimationUrl}";
				var baseUrl = $"{fileurl}?token={token}&email={email}";



				var emailRequest = new EmailRequest
				{
					To = registerModel?.Email,
					Body = EmailFormatter.FormatEmaiConfimation(baseUrl, rootPath),
					Subject = "Email Confirmation"
				};

				await _EmailService.SendMail(emailRequest);

				return new Response
				{
					StatusCode = StatusCodes.Status200OK,
					Data = new RegistrationResponseDto
					{
						Token = token,
						Message = "user created successfully"
					}
				};



			}
			catch (Exception ex)
			{

				//throw ex;
				return new Response
				{
					StatusCode = StatusCodes.Status500InternalServerError,
					Data = null,
					Error = new ErrorResponse
					{
						ErrorMesaage = "Internal server error occured"
					}
				};
			}
		}

		public async Task<Response> RegisterUser(RegisterModel registerModel)
		{
			try
			{
				var userExists = await _userManager.FindByNameAsync(registerModel.Username);
				if (userExists != null)
					return new Response
					{
						StatusCode = StatusCodes.Status400BadRequest,
						Data = null,
						Message = "User Already Exist"
						
					};
				ApplicationUser user = new()
				{
					Email = registerModel.Email,
					SecurityStamp = Guid.NewGuid().ToString(),
					UserName = registerModel.Username
				};
				var result = await _userManager.CreateAsync(user, registerModel.Password);

				if (!result.Succeeded)
				{
					string errorMessage = "";
					if (result.Errors.Count() > 0)
					{
						var errors = result.Errors;
						foreach (var error in errors)
						{
							errorMessage += $"{error.Description} \n";
						}
						return new Response
						{
							StatusCode = StatusCodes.Status400BadRequest,
							Message = errorMessage
						};
					}
					else
						return new Response { StatusCode = StatusCodes.Status500InternalServerError, Error = new ErrorResponse { ErrorMesaage = "Pls try again" } };

				}

				if (!await _roleManager.RoleExistsAsync(UserRoles.User))
					await _roleManager.CreateAsync(new ApplicationRole {  Name =UserRoles.User });

				var role = await _userManager.AddToRoleAsync(user, UserRoles.User);


				var time = DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss");
				var delimiter = $"{user.Email}^{time}";
				var email = _cryptographyService.Base64Encode(delimiter);
				
				var token = await _userManager.GenerateEmailConfirmationTokenAsync(user);

				var scheme = contextAccessor.HttpContext.Request.Scheme;
				var host = contextAccessor.HttpContext.Request.Host.Value;

				var fileurl = $"{scheme}://{host}/{EmailConfrimationUrl}";
				var baseUrl = $"{fileurl}?token={token}&email={email}";

				var emailRequest = new EmailRequest
				{
					To = registerModel?.Email,
					Body = EmailFormatter.FormatEmaiConfimation(baseUrl, rootPath),
					Subject = "Email Confirmation"
				};

				await _EmailService.SendMail(emailRequest);

				return new Response
				{
					StatusCode = StatusCodes.Status200OK,
					Data = new
					{
						Token = token,
						Message = "Thank you for your sign up, a confirmation link has been sent to your email address"
					}
				};
			}
			catch (Exception ex)
			{

				//throw ex;
				return new Response
				{
					StatusCode = StatusCodes.Status500InternalServerError,
					Data = null,
					Error = new ErrorResponse
					{
						ErrorMesaage = "Internal server error occured"
					}
				};

			}
		}

		public async Task<Response> Login(LoginModel loginModel)
		{
			try
			{
				var loginUser = await _userManager.FindByNameAsync(loginModel.Username);

	

				if (loginUser == null)
					loginUser= await _userManager.FindByEmailAsync(loginModel.Username);

				if(loginUser == null)
				return new Response
					{
						StatusCode = StatusCodes.Status401Unauthorized,
						Data = null,
						Message = "User does not exist"
					};


				
				var isPasswordValid = await _userManager.CheckPasswordAsync(loginUser, loginModel.Password);
				if (isPasswordValid)
				{
					var userRoles = await _userManager.GetRolesAsync(loginUser);
					var isEmailConfrimed = await _userManager.IsEmailConfirmedAsync(loginUser);
					if (!isEmailConfrimed && !userRoles.Contains("Super Administrator"))
					{
						var confirmationToken = await _userManager.GenerateEmailConfirmationTokenAsync(loginUser);
						var time = DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss");
						var delimiter = $"{loginUser.Email}^{time}";
						var email = _cryptographyService.Base64Encode(delimiter);


						var scheme = contextAccessor.HttpContext.Request.Scheme;
						var host = contextAccessor.HttpContext.Request.Host.Value;

						var fileurl = $"{scheme}://{host}/{EmailConfrimationUrl}";
						var baseUrl = $"{fileurl}?token={confirmationToken}&email={email}";

			
				
						var emailRequest = new EmailRequest
						{
							To = loginUser?.Email,
							Body = EmailFormatter.FormatEmaiConfimation(baseUrl, rootPath),
							Subject = "Email Confirmation"
						};

						await _EmailService.SendMail(emailRequest);

						return new Response
						{
							StatusCode = StatusCodes.Status401Unauthorized,
							Data = null,
							Message = "confrimation link has been sent to your email, kindly confirm your email"
						};

					}

					var authClaims = new List<Claim>
					{
						new Claim(ClaimTypes.Name, loginUser.UserName),
						new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
					};

					foreach (var userRole in userRoles)
					{
						authClaims.Add(new Claim(ClaimTypes.Role, userRole));
					}

					var token = GetToken(authClaims);
					//var authToken = JsonConvert.DeserializeObject<TokenViewModel>(token);

					return new Response
					{
						StatusCode = StatusCodes.Status200OK,
						Data = new LoginResponseDto
						{
							UserName = loginUser.UserName,
							Token = new JwtSecurityTokenHandler().WriteToken(token)
						},
						Message = "Login Sucessful"
					};
				}

				return new Response
				{
					StatusCode = StatusCodes.Status401Unauthorized,
					Data = null,
					Message = "password is not incorrect"
				};


			}
			catch (Exception ex)
			{
				return new Response
				{
					StatusCode = StatusCodes.Status500InternalServerError,
					Data = null,
					Error = new ErrorResponse
					{
						ErrorMesaage = "Internal server error occured"
					}
				};
			}
		}

		public async Task<Response> ConfirmEmail(ConfirmEmailDto model)
        {
            try
            {
				var email = _cryptographyService.Base64Decode(model.Email);
				var user = await _userManager.FindByEmailAsync(email);
				if (user == null)
					return new Response { StatusCode = StatusCodes.Status404NotFound, Message = "User does not exist" };

				IdentityResult result = await _userManager.ConfirmEmailAsync(user, model.Token);
				if (result.Succeeded)
					return new Response { StatusCode = StatusCodes.Status200OK, Message = "Email has been successfuly confirmed", };
				else
					return new Response { StatusCode = StatusCodes.Status400BadRequest, Message = String.Join(',', result.Errors.Select(x => x.Description)) };

			}
			catch (Exception ex)
			{
				return new Response { StatusCode = StatusCodes.Status500InternalServerError, Error = new ErrorResponse { ErrorMesaage = "Internal server Error occoured" } };
			}



		}


		public async Task<Response> RessetPassword(string email)
        {
            try
            {
				var user = await _userManager.FindByEmailAsync(email);
				if (user == null)
					return new Response { StatusCode = StatusCodes.Status404NotFound, Message = "User does not exist" };

				var token = await _cryptographyService.GenerateValidationTokenAsync(email);
				if(string.IsNullOrEmpty(token))
					return new Response { StatusCode = StatusCodes.Status417ExpectationFailed, Message = "we  are not able to process your request now, try again later" };

				return new Response { StatusCode = StatusCodes.Status200OK, Message = "token generated", Data = token };
			}
			catch (Exception ex)
            {
				return new Response { StatusCode = StatusCodes.Status500InternalServerError, Error = new ErrorResponse {ErrorMesaage = "Internal server Error occoured" } };
			}


		}

		public async Task<Response> ValidateToken(string token)
		{
			try
            {
				return await _cryptographyService.ValidateTokenAsync(token);
			}
			catch
			{
				return new Response { StatusCode = StatusCodes.Status500InternalServerError, Error = new ErrorResponse { ErrorMesaage = "Internal server Error occoured" } };
			}

		}

		public async Task<Response> ChangePassword(ChangePasswordDto model)
		{
			try
			{
				var user = await _userManager.FindByEmailAsync(model.Email);
				if (user == null)
					return new Response { StatusCode = StatusCodes.Status404NotFound, Message = "User does not exist" };

				var token =  await _userManager.GeneratePasswordResetTokenAsync(user);
				IdentityResult result = await _userManager.ResetPasswordAsync(user, token, model.Password);

				if(!result.Succeeded)
					return new Response { StatusCode = StatusCodes.Status417ExpectationFailed, Message = "Password reset failed" };

				return new Response { StatusCode = StatusCodes.Status200OK, Message = "Password reset was successful" };

			}
			catch
			{
				return new Response { StatusCode = StatusCodes.Status500InternalServerError, Error = new ErrorResponse { ErrorMesaage = "Internal server Error occoured" } };
			}

		}



		private JwtSecurityToken GetToken(List<Claim> authClaims)
		{
			var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]));

			var token = new JwtSecurityToken(
			  issuer: _configuration["JWT:ValidIssuer"],
			  audience: _configuration["JWT:ValidAudience"],
			  expires: DateTime.Now.AddHours(3),
			  claims: authClaims,
			  signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
			  );

			return token;
		}
	}
}

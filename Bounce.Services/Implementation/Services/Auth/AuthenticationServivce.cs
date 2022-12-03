using Bounce.DataTransferObject.DTO.Auth;
using Bounce.DataTransferObject.Helpers.BaseResponse;
using Bounce_Application.Cryptography.Hash;
using Bounce_Application.DTO;
using Bounce_Application.DTO.Auth;
using Bounce_Application.Persistence.Interfaces.Auth;
using Bounce_Application.Persistence.Interfaces.Helper;
using Bounce_Application.SeriLog;
using Bounce_Application.Utilies;
using Bounce_Applucation.DTO.Auth;
using Bounce_DbOps.EF;
using Bounce_Domain.Entity;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Bounce.Services.Implementation.Services.Auth
{
    public class AuthenticationServivce : BaseServices, IAuthenticationServivce
    {

        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> signInManager;
        private readonly RoleManager<ApplicationRole> _roleManager;
        private readonly IConfiguration _configuration;
        private readonly IHostingEnvironment _hostingEnvironment;
        private readonly IEmalService _EmailService;
        private readonly ICryptographyService _cryptographyService;
        private readonly IHttpContextAccessor contextAccessor;
        private readonly AdminLogger _adminLogger;
        private static string EmailConfrimationUrl = "Bounce/ConfirmEmail";
        public string rootPath { get; set; }
        public AuthenticationServivce(BounceDbContext context, UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, RoleManager<ApplicationRole> roleManager, IConfiguration configuration, IHostingEnvironment hostingEnvironment, IEmalService emailService, ICryptographyService cryptographyService, IHttpContextAccessor contextAccessor, AdminLogger adminLogger) : base(context)
        {
            _userManager = userManager;
            this.signInManager = signInManager;
            _roleManager = roleManager;
            _configuration = configuration;
            _hostingEnvironment = hostingEnvironment;
            _EmailService = emailService;
            _cryptographyService = cryptographyService;
            this.contextAccessor = contextAccessor;
            _adminLogger = adminLogger;
            rootPath = _hostingEnvironment.ContentRootPath;
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
                        Message = "User Already Exist"

                    };
                ApplicationUser user = new()
                {
                    Email = registerModel.Email,
                    SecurityStamp = Guid.NewGuid().ToString(),
                    UserName = registerModel.Username,
                    Discriminator = Bounce_Domain.Enum.UserType.Admin
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
                        return new Response { StatusCode = StatusCodes.Status500InternalServerError, Message = InterErrorMessage };

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
                return InternalErrorResponse(ex);

            }
        }

        public async Task<Response> RegisterSuperAdminUser(RegisterModel registerModel)
        {
            try
            {

                var userExists = _userManager.Users.Any(x => x.UserName == registerModel.Username || x.Email == registerModel.Email);
                if (userExists)
                {
                    return new Response
                    {
                        StatusCode = StatusCodes.Status409Conflict,
                        Message = "User Already Exist"

                    };

                }
                   
                ApplicationUser user = new()
                {
                    Email = registerModel.Email,
                    SecurityStamp = Guid.NewGuid().ToString(),
                    UserName = registerModel.Username,
                    Discriminator = Bounce_Domain.Enum.UserType.Admin,
                    EmailConfirmed = true,
                    HasProfile = true
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
                        return new Response { StatusCode = StatusCodes.Status500InternalServerError, Message = InterErrorMessage };

                }

                if (!await _roleManager.RoleExistsAsync(UserRoles.SuperAdministrator))
                    await _roleManager.CreateAsync(new ApplicationRole { Name = UserRoles.SuperAdministrator });

                var role = await _userManager.AddToRoleAsync(user, UserRoles.SuperAdministrator);


                var token = await _userManager.GenerateEmailConfirmationTokenAsync(user);


                //var scheme = contextAccessor.HttpContext.Request.Scheme;
                //var host = contextAccessor.HttpContext.Request.Host.Value;

                //var fileurl = $"{scheme}://{host}/{EmailConfrimationUrl}";
                //var baseUrl = $"{fileurl}?token={token}&email={email}";

                //var emailRequest = new EmailRequest
                //{
                //    To = registerModel?.Email,
                //    Body = EmailFormatter.FormatEmaiConfimation(baseUrl, rootPath),
                //    Subject = "Email Confirmation"
                //};

                //await _EmailService.SendMail(emailRequest);

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
                return InternalErrorResponse(ex);

            }
        }

        public async Task<Response> RegisterTherapist(RegisterModel registerModel)
        {
            try
            {
                var userExists =  _userManager.Users.Any(x=> x.UserName == registerModel.Username || x.Email == registerModel.Email);
                if (userExists)
                    return new Response
                    {
                        StatusCode = StatusCodes.Status400BadRequest,
                        Data = null,
                        Message = "User Already Exist"
                    };
                var therapistId = await _cryptographyService.GeneratePatientIdAsync("BNT");
                ApplicationUser user = new()
                {
                    Email = registerModel.Email,
                    SecurityStamp = Guid.NewGuid().ToString(),
                    UserName = registerModel.Username,
                    Discriminator = Bounce_Domain.Enum.UserType.Therapist,
                    PatientId = therapistId
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
                        return new Response { StatusCode = StatusCodes.Status500InternalServerError, Message = InterErrorMessage };

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

                await _EmailService.SendMail(emailRequest);

                var loginUser = _userManager.Users.FirstOrDefault(x => x.Email == user.Email);
                var accessToken = await GenerateAccessToken(loginUser);
                return new Response
                {
                    StatusCode = StatusCodes.Status200OK,
                    Data = new RegistrationResponseDto
                    {
                        Token = accessToken,
                        Message = "user created successfully"
                    }
                };



            }
            catch (Exception ex)
            {
                return InternalErrorResponse(ex);
            }
        }

        public async Task<Response> RegisterUser(RegisterModel registerModel)
        {
            try
            {

                var userExists = _userManager.Users.Any(x => x.UserName == registerModel.Username || x.Email == registerModel.Email);
                if (userExists)
                    return new Response
                    {
                        StatusCode = StatusCodes.Status400BadRequest,
                        Message = "User Already Exist"

                    };

                var patientId = await _cryptographyService.GeneratePatientIdAsync();
                ApplicationUser user = new()
                {
                    Email = registerModel.Email,
                    SecurityStamp = Guid.NewGuid().ToString(),
                    UserName = registerModel.Username,
                    Discriminator = Bounce_Domain.Enum.UserType.Patient,
                    PatientId = patientId
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
                        return new Response { StatusCode = StatusCodes.Status500InternalServerError, Message = InterErrorMessage };

                }

                if (!await _roleManager.RoleExistsAsync(UserRoles.User))
                    await _roleManager.CreateAsync(new ApplicationRole { Name = UserRoles.User });

                var role = await _userManager.AddToRoleAsync(user, UserRoles.User);


                var time = DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss");
                var delimiter = $"{user.Email}^{time}";
                var email = _cryptographyService.Base64Encode(delimiter);

                var token = await _userManager.GenerateEmailConfirmationTokenAsync(user);

                user = await _userManager.FindByEmailAsync(registerModel.Email);

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

                var loginUser = _userManager.Users.FirstOrDefault(x => x.Email == user.Email);
                var accessToken = await GenerateAccessToken(loginUser);

                return new Response
                {
                    StatusCode = StatusCodes.Status200OK,
                    Data = new
                    {
                        Token = accessToken,
                        email = registerModel.Email,
                        UserId = user.Id,
                        Message = "Thank you for your sign up, a confirmation link has been sent to your email address"
                    }
                };
            }
            catch (Exception ex)
            {
                return InternalErrorResponse(ex);

            }
        }


        public async Task<Response> ConfirmLogin(LoginModel loginModel)
        {
            var result = await signInManager.TwoFactorSignInAsync(loginModel.Username, loginModel.Password, false, false);
            if (result.Succeeded)
            {
                return new Response
                {
                    StatusCode = StatusCodes.Status401Unauthorized,
                    Message = "Succeeded"
                };
            }
            return new Response
            {
                StatusCode = StatusCodes.Status401Unauthorized,
                Message = "Invalid Password"
            };
        }
        public async Task<Response> TempLogin(LoginModel loginModel)
        {
            try
            {

                var loginUser = await _userManager.FindByNameAsync(loginModel.Username);



                if (loginUser == null)
                    loginUser = await _userManager.FindByEmailAsync(loginModel.Username);

                if (loginUser == null)
                    return new Response
                    {
                        StatusCode = StatusCodes.Status401Unauthorized,
                        Message = "User does not exist"
                    };


                var isPasswordValid = await _userManager.CheckPasswordAsync(loginUser, loginModel.Password);
                if (isPasswordValid)
                {
                    var userRoles = await _userManager.GetRolesAsync(loginUser);
                    var isEmailConfrimed = await _userManager.IsEmailConfirmedAsync(loginUser);


                    var providers = await _userManager.GetValidTwoFactorProvidersAsync(loginUser);
                    if (!providers.Contains(loginUser.Email))
                    {
                        var sfsfsfsf = "";
                    }
                    var token = await _userManager.GenerateTwoFactorTokenAsync(loginUser, loginUser.Email);



                    return new Response
                    {
                        StatusCode = StatusCodes.Status200OK,
                        Data = new
                        {
                            UserName = loginUser.UserName,
                            Email = loginUser.Email,
                            Token = token,
                            UserId = loginUser.Id,
                            EmailConfirmed = isEmailConfrimed
                        },
                        Message = "Login was successful"
                        //{
                        //	UserName = loginUser.UserName,

                        //	Token = /*new JwtSecurityTokenHandler().WriteToken(token)*/ token
                        //},

                    };
                }

                return new Response
                {
                    StatusCode = StatusCodes.Status401Unauthorized,
                    Message = "Invalid Password"
                };


            }
            catch (Exception ex)
            {
                return InternalErrorResponse(ex);
            }
        }

        public async Task<Response> Login(LoginModel loginModel)
        {
            try
            {

                var loginUser =  _userManager.Users.FirstOrDefault(x=> x.UserName == loginModel.Username
                || x.PatientId == loginModel.Username || x.Email == loginModel.Username);

                if (loginUser == null)
                    return new Response
                    {
                        StatusCode = StatusCodes.Status401Unauthorized,
                        Message = "User does not exist"
                    };

       
                var isPasswordValid = await _userManager.CheckPasswordAsync(loginUser, loginModel.Password);
                if (isPasswordValid)
                {
                    var existingWallet = _context.Wallets.FirstOrDefault(x => x.UserId == loginUser.Id);
                    if (existingWallet == null)
                    {
                        var wallet = new Wallet
                        {
                            UserId = loginUser.Id,
                            Balance = 0,
                            AvailableBalance = 0,
                            ReferalBonus = 0,
                            DateCreated = DateTime.Now
                        };
                        _context.Add(wallet);
                        _context.SaveChanges();
                    }


                    var userRoles = await _userManager.GetRolesAsync(loginUser);
                    var isEmailConfrimed = await _userManager.IsEmailConfirmedAsync(loginUser);

                    #region
                    if (!isEmailConfrimed && !userRoles.Contains("Super Administrator"))
                    {
                      


                        if (userRoles.Contains(UserRoles.Therapist))
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
                        #endregion
                    }

                  

                    var token = await GenerateAccessToken(loginUser);
                    var roles = string.Join(",", userRoles);
                    //var authToken = JsonConvert.DeserializeObject<TokenViewModel>(token);
                    var image = "";
               
                    if(userRoles.Contains(UserRoles.User))
                    {
                        var userProfile = _context.UserProfile.FirstOrDefault(x => x.UserId == loginUser.Id);
                        if(userProfile != null)
                        {
                            image = !string.IsNullOrEmpty(userProfile.FilePath) ? userProfile.FilePath : null;
                        }
                        
                    }
                    else if (userRoles.Contains(UserRoles.Therapist))
                    {
                        var userProfile = _context.TherapistProfiles.FirstOrDefault(x => x.UserId == loginUser.Id);
                        if (userProfile != null)
                        {
                            image = !string.IsNullOrEmpty(userProfile.ProfilePicture) ? userProfile.ProfilePicture : null;
                        }
                        
                    }
                    else
                    {
                        image = null;
                    }


                    return new Response
                    {
                        StatusCode = StatusCodes.Status200OK,
                        Data = new
                        {
                            Token = token,
                            UserName = loginUser.UserName,
                            Email = loginUser.Email,
                            Role = userRoles.FirstOrDefault(),
                            Phone = loginUser?.PhoneNumber,
                            HasProfile = loginUser?.HasProfile,
                            ConfirmedEmail = loginUser?.EmailConfirmed,
                            UserId = loginUser?.Id,
                            Image = image,
                        },
                        Message = "Login Sucessful"
                    };
                }

                return new Response
                {
                    StatusCode = StatusCodes.Status401Unauthorized,
                    Message = "Invalid Password"
                };


            }
            catch (Exception ex)
            {
                return InternalErrorResponse(ex);
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
                {
                    var wallet = new Wallet
                    {
                        UserId = user.Id
                    };
                    _context.Add(wallet);
                    _context.SaveChanges();
                    
                    return new Response { StatusCode = StatusCodes.Status200OK, Message = "Email has been successfuly confirmed", };
                }
                else
                    return new Response { StatusCode = StatusCodes.Status400BadRequest, Message = String.Join(',', result.Errors.Select(x => x.Description)) };

            }
            catch (Exception ex)
            {
                return InternalErrorResponse(ex);
            }

        }

        public async Task<Response> EmailConfirmationStatus(string userEmail)
        {
            try
            {

                var user = await _userManager.FindByEmailAsync(userEmail);
                if (user == null)
                    return new Response { StatusCode = StatusCodes.Status404NotFound, Message = "User does not exist" };

                var isEmailConfrimed = await _userManager.IsEmailConfirmedAsync(user);
                if (isEmailConfrimed)
                    return new Response { StatusCode = StatusCodes.Status200OK, Data = true, Message = "Email has been verified already" };
                return new Response { StatusCode = StatusCodes.Status200OK, Data = false, Message = "Email has not been verified" };

            }
            catch (Exception ex)
            {
                return InternalErrorResponse(ex);
            }

        }


        public async Task<Response> SendEmailConfrimationLink(string userEmail)
        {
            try
            {

                var user = await _userManager.FindByEmailAsync(userEmail);
                if (user == null)
                    return new Response { StatusCode = StatusCodes.Status404NotFound, Message = "User does not exist" };

                var isEmailConfrimed = await _userManager.IsEmailConfirmedAsync(user);
                if (isEmailConfrimed)
                    return new Response { StatusCode = StatusCodes.Status404NotFound, Message = "Email has been confirmed already" };



                var time = DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss");
                var delimiter = $"{user.Email}^{time}";
                var encryptedemail = _cryptographyService.Base64Encode(delimiter);

                var token = await _userManager.GenerateEmailConfirmationTokenAsync(user);


                var scheme = contextAccessor.HttpContext.Request.Scheme;
                var host = contextAccessor.HttpContext.Request.Host.Value;

                var fileurl = $"{scheme}://{host}/{EmailConfrimationUrl}";
                var baseUrl = $"{fileurl}?token={token}&email={encryptedemail}";

                var emailRequest = new EmailRequest
                {
                    To = userEmail,
                    Body = EmailFormatter.FormatEmaiConfimation(baseUrl, rootPath),
                    Subject = "Email Confirmation"
                };

                await _EmailService.SendMail(emailRequest);

                return new Response { StatusCode = StatusCodes.Status200OK, Message = "Email confirmation link has been successfuly sent to your email" };


            }
            catch (Exception ex)
            {
                return InternalErrorResponse(ex);
            }

        }


        public async Task<Response> ResetPassword(string email)
        {
            try
            {
                var user = await _userManager.FindByEmailAsync(email);
                if (user == null)
                    return new Response { StatusCode = StatusCodes.Status404NotFound, Message = "User does not exist" };

                var token = await _cryptographyService.GenerateValidationTokenAsync(email);
                if (string.IsNullOrEmpty(token))
                    return new Response { StatusCode = StatusCodes.Status417ExpectationFailed, Message = "we  are not able to process your request now, try again later" };


                var emailRequest = new EmailRequest
                {
                    To = email,
                    Body = EmailFormatter.FormatTokenEmail(token, rootPath),
                    Subject = "Password Resset"
                };

                await _EmailService.SendMail(emailRequest);


                return new Response { StatusCode = StatusCodes.Status200OK, Message = "token has been sent to your email" };
            }
            catch (Exception ex)
            {
                return InternalErrorResponse(ex);
            }


        }

        public async Task<Response> ValidateToken(string token)
        {
            try
            {
                return await _cryptographyService.ValidateTokenAsync(token);
            }
            catch (Exception ex)
            {
                return InternalErrorResponse(ex);
            }

        }

        public async Task<Response> ChangePassword(ChangePasswordDto model)
        {
            try
            {
                var user = await _userManager.FindByEmailAsync(model.Email);
                if (user == null)
                    return new Response { StatusCode = StatusCodes.Status404NotFound, Message = "User does not exist" };

                var token = await _userManager.GeneratePasswordResetTokenAsync(user);
                IdentityResult result = await _userManager.ResetPasswordAsync(user, token, model.Password);

                if (!result.Succeeded)
                    return new Response { StatusCode = StatusCodes.Status417ExpectationFailed, Message = "Password reset failed" };


                return new Response { StatusCode = StatusCodes.Status200OK, Message = "Password reset was successful" };

            }
            catch (Exception ex)
            {
                return InternalErrorResponse(ex);
            }

        }

        public async Task<string> GenerateAccessToken(ApplicationUser user)
        {
            //var user = _context.personalInformations.FirstOrDefault(x => x.ID == userId);
            //var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]));
            //var apiKey = Environment.GetEnvironmentVariable("apiKey");
            var tokenHandler = new JwtSecurityTokenHandler();// for creatiing token
            var keyValue = _configuration["JWT:Secret"];
            var key = Encoding.ASCII.GetBytes(keyValue);
            var userRoles = await _userManager.GetRolesAsync(user);
            var claims = new List<Claim>();
            claims.Add(new Claim("userId", Convert.ToString(user.Id)));
            //claims.Add(new Claim("applicationUserId", applicationUserId));
            claims.Add(new Claim("userEmail", user.Email));
            claims.Add(new Claim("userName", user.UserName));

            foreach (var role in userRoles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                //Expires = DateTime.UtcNow.AddDays(30),
                Expires = DateTime.UtcNow.AddDays(30),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key)
, SecurityAlgorithms.HmacSha256Signature),
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }


    }
}

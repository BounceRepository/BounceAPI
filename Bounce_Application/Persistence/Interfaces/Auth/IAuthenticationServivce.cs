﻿
using Bounce.DataTransferObject.DTO.Auth;
using Bounce.DataTransferObject.DTO.Auth.Response;
using Bounce.DataTransferObject.Helpers.BaseResponse;
using Bounce_Application.DTO;
using Bounce_Application.DTO.Auth;

namespace Bounce_Application.Persistence.Interfaces.Auth
{
    public interface IAuthenticationServivce
    {
        Task<Response> RegisterAdminUser(RegisterModel registerModel);
        Task<Response> RegisterUser(RegisterModel unregisterModel);
        Task<Response> RegisterTherapist(RegisterModel registerModel);
        Task<Response> Login(LoginModel loginModel); 
        Task<Response> TempLogin(LoginModel loginModel);

        Task<Response> ConfirmLogin(LoginModel loginModel);
        Task<Response> ResetPassword(string email);
        Task<Response> ValidateToken(string token);
        Task<Response> ChangePassword(ChangePasswordDto model);
        Task<Response> ConfirmEmail(ConfirmEmailDto model);
        Task<Response> SendEmailConfrimationLink(string userEmail);
        Task<Response> EmailConfirmationStatus(string userEmail);
        Task<Response> RegisterSuperAdminUser(RegisterModel registerModel);
        Task<Response> TherapistLogin(LoginModel loginModel);
        Task<Response> PatientLogin(LoginModel loginModel);
    }
}

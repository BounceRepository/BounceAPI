using AutoMapper;
using Bounce.DataTransferObject.DTO.Notification;
using Bounce.DataTransferObject.Helpers.BaseResponse;
using Bounce_Application.Persistence.Interfaces.Helper;
using Bounce_Application.Persistence.Interfaces.Notification;
using Bounce_Application.Utilies;
using Bounce_DbOps.EF;
using Bounce_Domain.Entity;
using FirebaseAdmin;
using FirebaseAdmin.Messaging;
using Google.Apis.Auth.OAuth2;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Bounce.Services.Implementation.Services.Notification
{
    public class NotificationService: BaseServices, INotificationService
    {
        private readonly IMapper _mapper;
        private readonly SessionManager _sessionManager;
        private readonly UserManager<ApplicationUser>  _userManager;
        private readonly IHostingEnvironment _hostingEnvironment;
        private readonly IEmalService _EmailService;
        public string rootPath { get; set; }

        public NotificationService(BounceDbContext context, IMapper mapper, SessionManager sessionManager, UserManager<ApplicationUser> userManager, IHostingEnvironment hostingEnvironment, IEmalService emailService) : base(context)
        {
            _mapper = mapper;
            _sessionManager = sessionManager;
            _userManager = userManager;
            _hostingEnvironment = hostingEnvironment;
            rootPath = _hostingEnvironment.ContentRootPath;
            _EmailService = emailService;
            rootPath = _hostingEnvironment.ContentRootPath;
        }
        public async Task<Response>  PushNotification(PushNotificationDto model)
        {
            try
            {
                var user = _sessionManager.CurrentLogin;
                var defaultApp = FirebaseApp.Create(new AppOptions()
                {
                    Credential = GoogleCredential.FromFile(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "key.json")),
                });

                var message = new Message()
                {
                    
                    Data = new Dictionary<string, string>()
                    {
                        ["User"] = user.Email,
                        ["UserName"] = user.UserName,

                    },
                    Notification = new FirebaseAdmin.Messaging.Notification
                    {
                        Title = model.Title,
                        Body = model.Message,
                        
                    },
                    //Token = user.NotificationToken,
                    Topic = Regex.Replace(model.Topic, @"\s", "")
                };
                var messaging = FirebaseMessaging.DefaultInstance;
                var result = await messaging.SendAsync(message);

                return SuccessResponse();

            }
            catch(Exception ex)
            {
                return InternalErrorResponse(ex);
            }
        }
     
        public async Task<Response> ReadNotification(long notificationId)
        {
            try
            {
                var notification = _context.Notification.FirstOrDefault(x => x.Id == notificationId);
                notification.IsNewNotication = false;
                _context.Update(notification);
                if (!await SaveAsync())
                    return FailedSaveResponse(notification);
                return SuccessResponse();

            }
            catch (Exception ex)
            {
                return InternalErrorResponse(ex);
            }
        }
        public async Task<Response> UpdateNotificationToken(string notificationToken)
        {
            try
            {
                var user = _sessionManager.CurrentLogin;
                user.NotificationToken = notificationToken;
                await _userManager.UpdateAsync(user);
                return SuccessResponse("token has been updated");

            }
            catch (Exception ex)
            {
                return InternalErrorResponse(ex);
            }
        }
        public async Task<Response> PopNotification(long notificationId)
        {
            try
            {
                var notification = _context.Notification.FirstOrDefault(x => x.Id == notificationId);
                notification.IsDeleted = true;
                _context.Update(notification);
                if (!await SaveAsync())
                    return FailedSaveResponse(notification);
                return SuccessResponse();

            }
            catch (Exception ex)
            {
                return InternalErrorResponse(ex);
            }
        }
        public Response GetAllNotification()
        {
            try
            {
                var notifications = _context.Notification.Where(x => x.IsDeleted && x.Id == _sessionManager.CurrentLogin.Id)
                    .OrderByDescending(x=> x.DateCreated).ToList();
                var totalnotication = notifications.Count();
                var totalOpenNotifcation = notifications.Where(x => x.IsNewNotication).Count();


                var records = notifications.Select(x => new ListNotificationsDto
                {
                    NotificationId = x.Id,
                    Message = x.Message,
                    Title = x.Title,
                    Time = x.DateCreated
                });
                var data = new
                {
                    Total = totalnotication,
                    TotalOpenNotifcation = totalOpenNotifcation,
                    Records = records
                };
  
                return SuccessResponse(data: data);

            }
            catch (Exception ex)
            {
                return InternalErrorResponse(ex);
            }
        }
    }
}

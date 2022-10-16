using AutoMapper;
using Bounce.DataTransferObject.DTO.Notification;
using Bounce.DataTransferObject.Helpers.BaseResponse;
using Bounce_Application.Persistence.Interfaces.Notification;
using Bounce_Application.Utilies;
using Bounce_DbOps.EF;
using Bounce_Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bounce.Services.Implementation.Services.Notification
{
    public class NotificationService: BaseServices, INotificationService
    {
        private readonly IMapper _mapper;
        private readonly SessionManager _sessionManager;

        public NotificationService(BounceDbContext context, IMapper mapper, SessionManager sessionManager) : base(context)
        {
            _mapper = mapper;
            _sessionManager = sessionManager;
        }
        public async Task<Response>  PushNotification(PushNotificationDto model)
        {
            try
            {
               var notification = _mapper.Map<Notifications>(model);
               await _context.AddAsync(notification);
                if (!await SaveAsync())
                    return FailedSaveResponse(notification);
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
                var notification = _context.Notifications.FirstOrDefault(x => x.Id == notificationId);
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
        public async Task<Response> PopNotification(long notificationId)
        {
            try
            {
                var notification = _context.Notifications.FirstOrDefault(x => x.Id == notificationId);
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
                var notifications = _context.Notifications.Where(x => x.IsDeleted && x.Id == _sessionManager.CurrentLogin.Id)
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

using Bounce.DataTransferObject.DTO.Notification;
using Bounce.DataTransferObject.Helpers.BaseResponse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bounce_Application.Persistence.Interfaces.Notification
{
    public interface INotificationService
    {
        Response GetAllNotification();
        Task<Response> PopNotification(long notificationId);
        Task<Response> PushNotification(PushNotificationDto model);
        Task<Response> ReadNotification(long notificationId);
        Task<Response> UpdateNotificationToken(string notificationToken);
    }
}

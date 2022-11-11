using Bounce.DataTransferObject.DTO.Notification;
using Bounce_Application.Persistence.Interfaces.Notification;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Bounce.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotificationController : BaseController
    {
        private readonly INotificationService _notificationService;

        public NotificationController(IHttpContextAccessor httpContext, INotificationService notificationService) : base(httpContext)
        {
            _notificationService = notificationService;
        }

        [HttpPost("PushNotification")]
        public async Task<IActionResult> PushNotification([FromBody] PushNotificationDto model) => Response(await _notificationService.PushNotification(model));
        [HttpPatch("UpdateNotificationToken")]
        public async Task<IActionResult> Updatetoken([FromQuery] string token) => Response( await _notificationService.UpdateNotificationToken(token));

        [HttpGet("GetAllUserNotifications")]
        public IActionResult GetAllNotification() => Response(_notificationService.GetAllNotification());

        [HttpPost("ReadNotification")]
        public async Task<IActionResult> ReadNotification([FromQuery] long notificationid) => Response(await _notificationService.ReadNotification(notificationid));

        [HttpDelete("DeleteNotification")]
        public async Task<IActionResult> PopNotification([FromQuery] long notificationid) => Response( await _notificationService.PopNotification(notificationid));

    }




}

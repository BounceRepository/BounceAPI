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

        [HttpGet("GetAllUserNotifications")]
        public IActionResult GetAllNotification() => Response(_notificationService.GetAllNotification());

        [HttpPost("ReadNotification")]
        public async Task<IActionResult> ReadNotification([FromQuery] long notificationid) => Response(await _notificationService.ReadNotification(notificationid));

        [HttpDelete("DeleteNotification")]
        public async Task<IActionResult> PopNotification([FromQuery] long notificationid) => Response( await _notificationService.PopNotification(notificationid));
    }


  

}

using Bounce.Api.ChatHub;
using Bounce.DataTransferObject.DTO.Notification;
using Bounce_Application.Persistence.Interfaces.Notification;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

namespace Bounce.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class NotificationController : BaseController
    {
        private readonly INotificationService _notificationService;
        private readonly IHubContext<BounceChatHub> _chatHubContext;

        public NotificationController(IHttpContextAccessor httpContext, INotificationService notificationService, IHubContext<BounceChatHub> chatHubContext) : base(httpContext)
        {
            _notificationService = notificationService;
            _chatHubContext = chatHubContext;
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

        [HttpPost("PushMessage")]
        public async Task<IActionResult> PushMessage([FromBody] ChatHubDto model)
        {
            try
            {
                await _chatHubContext.Clients.All.SendAsync("ReceievedMessage", model);

                return Ok(new { Message = "Message sent" });
            }
            catch
            {
                return StatusCode(500);
            }
          
        }

        [HttpPost("SendMessage")]
        public async Task<IActionResult> Chat([FromForm] SendMessageDto model) => Response(await _notificationService.SendMessage(model));

        [HttpGet("GetAllChatMessages")]
        public IActionResult AllChat() => Response( _notificationService.GetMessages());
        
        [HttpGet("GetAllFeedGroups")]
        public IActionResult FeedGroup() => Response(_notificationService.GetFeedGroups());

        [HttpPost("CreateNewFeed")]
        public async Task<IActionResult> NewFeed([FromBody] CreateFeedDto model) => Response(await _notificationService.CreateFeed(model));

       
        [HttpGet("GetAllFeeds")]
        public IActionResult AllFedds() => Response(_notificationService.GetAllFeeds());

        [HttpPatch("LikeFeed")]
        public async Task<IActionResult> LikeFeed([FromBody] FeedLikeDto model) => Response(await _notificationService.LikeFeed(model));

        [HttpGet("GetAllFeedsByUser")]
        public IActionResult UserFedds() => Response(_notificationService.GetUserFeeds());

        [HttpPost("CreateComment")]
        public async Task<IActionResult> Comment([FromBody] CommentDto model) => Response(await _notificationService.CreateComent(model));

        [HttpPatch("LikeComment")]
        public async Task<IActionResult> LikeFeed([FromBody] CommentLikeDto model) => Response(await _notificationService.LikeComment(model));
        [HttpPost("CreateReplyOnComment")]
        public async Task<IActionResult> ReplyComment([FromBody] PushReplyDto model) => Response(await _notificationService.ReplyComent(model));

        [HttpGet("GetCommentsByFeedId")]
        public IActionResult GetComment([FromQuery] long feedId) => Response(_notificationService.GetCommentByFeedId(feedId));

        [HttpGet("GetReplyByCommentId")]
        public IActionResult GetREplies([FromQuery] long commentId) => Response(_notificationService.GetRepliesByCommentId(commentId));



    }




}

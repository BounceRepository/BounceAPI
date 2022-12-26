﻿using Bounce.Api.ChatHub;
using Bounce.DataTransferObject.DTO.Notification;
using Bounce_Application.Persistence.Interfaces.Notification;
using Bounce_DbOps.EF;
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
        private readonly BounceDbContext _context;

        public NotificationController(IHttpContextAccessor httpContext, INotificationService notificationService, IHubContext<BounceChatHub> chatHubContext, BounceDbContext context) : base(httpContext)
        {
            _notificationService = notificationService;
            _chatHubContext = chatHubContext;
            _context = context;
        }

        [HttpPost("PushNotification")]
        public async Task<IActionResult> PushNotification([FromBody] PushNotificationDto model) => Response(await _notificationService.PushNotification(model));
        [HttpPatch("UpdateNotificationToken")]
        public async Task<IActionResult> Updatetoken([FromQuery] string token) => Response( await _notificationService.UpdateNotificationToken(token));

        [HttpGet("GetAllUserNotifications")]
        public IActionResult GetAllNotification() => Response(_notificationService.GetAllNotification());

        [HttpPost("ReadNotification")]
        public async Task<IActionResult> ReadNotification() => Response(await _notificationService.ReadNotification());

        [HttpDelete("DeleteNotification")]
        public async Task<IActionResult> PopNotification([FromQuery] long notificationid) => Response( await _notificationService.PopNotification(notificationid));

        [HttpPost("PushMessage")]
        public async Task<IActionResult> PushMessage([FromBody] ChatHubDto model)
        {
            try
            {
                var receiver = _context.Users.FirstOrDefault(x => x.Id == model.RevceieverId);            
                if (receiver != null)
                {

                   
                    var message = new SendMessageDto
                    {
                        ReceieverId = model.RevceieverId,
                        Message = model.Message,
                        Time = DateTime.UtcNow,
                        FilePath = model.FilePaths 

                    };
                   var response =  await _notificationService.SendMessage(message);

                    if (response.StatusCode == 200)
                    {
                        await _chatHubContext.Clients.All.SendAsync("OnMessage", message);

                        return Ok(new { Message = "Message sent" });
                    }
                    
                    return Ok(new { Message = "Message not sent" });

                }

                return BadRequest(new { Message = "user was not found"});
            }
            catch
            {
                return StatusCode(500);
            }
          
        }

        [HttpPost("SendMessage")]
        public async Task<IActionResult> Chat([FromForm] SendMessageDto model) => Response(await _notificationService.SendMessage(model));

        [HttpGet("GetAllChatMessages")]
        public IActionResult AllChat([FromQuery] long receiverId) => Response( _notificationService.GetMessagesByUserId(receiverId));
        
        [HttpGet("GetAllFeedGroups")]
        public IActionResult FeedGroup() => Response(_notificationService.GetFeedGroups());

        [HttpPost("CreateNewFeed")]
        public async Task<IActionResult> NewFeed([FromBody] CreateFeedDto model) => Response(await _notificationService.CreateFeed(model));

       
        [HttpGet("GetAllFeeds")]
        public IActionResult AllFedds() => Response(_notificationService.GetAllFeeds());

        [AllowAnonymous]
        [HttpGet("GetAllFeedsGroupById")]
        public IActionResult GetAllFeedsGroupById([FromQuery] long groupId) => Response(_notificationService.GetAllFeedsByGroupId(groupId));

        [HttpPatch("LikeFeed")]
        public async Task<IActionResult> LikeFeed([FromBody] FeedLikeDto model) => Response(await _notificationService.LikeFeed(model));

        [HttpGet("GetAllFeedsByUser")]
        public IActionResult UserFedds() => Response(_notificationService.GetUserFeeds());

        [HttpPost("CreateComment")]
        public async Task<IActionResult> Comment([FromBody] CommentDto model) => Response(await _notificationService.CreateComent(model));

        [HttpPatch("LikeComment")]
        public async Task<IActionResult> LikeComment([FromBody] CommentLikeDto model) => Response(await _notificationService.LikeComment(model));
        [HttpPost("CreateReplyOnComment")]
        public async Task<IActionResult> ReplyComment([FromBody] PushReplyDto model) => Response(await _notificationService.ReplyComent(model));

        [HttpGet("GetCommentsByFeedId")]
        public IActionResult GetComment([FromQuery] long feedId) => Response(_notificationService.GetCommentByFeedId(feedId));

        [HttpGet("GetReplyByCommentId")]
        public IActionResult GetREplies([FromQuery] long commentId) => Response(_notificationService.GetRepliesByCommentId(commentId));



    }




}

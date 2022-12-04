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
        Task<Response> CreateComent(CommentDto model);
        Task<Response> CreateFeed(CreateFeedDto model);
        Response GetAllFeeds();
        Response GetAllFeedsByGroupId(long groupId);
        Response GetAllNotification();
        Response GetCommentByFeedId(long feedId);
        Response GetFeedGroups();
        Response GetMessages();
        Response GetMessagesByUserId(long rceieverId);
        Response GetRepliesByCommentId(long commentId);
        Response GetUserFeeds();
        Task<Response> LikeComment(CommentLikeDto model);
        Task<Response> LikeFeed(FeedLikeDto model);
        Task<Response> LikReply(ReplyLikeDto model);
        Task<Response> PopNotification(long notificationId);
        Task<Response> PushNotification(PushNotificationDto model);
        Task<Response> ReadNotification();
        Task<Response> ReplyComent(PushReplyDto model);
        Task<Response> SendMessage(SendMessageDto model);
        Task<Response> UpdateNotificationToken(string notificationToken);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bounce.DataTransferObject.DTO.Notification
{
    public class FeedLikeDto
    {
        public long FeedId { get; set; }
    }
    public class CommentLikeDto
    {
        public long CommentId { get; set; }
    }
    public class ReplyLikeDto
    {
        public long ReplyId { get; set; }
    }
}

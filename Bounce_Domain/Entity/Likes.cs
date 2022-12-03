using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bounce_Domain.Entity
{
    public class Likes : BaseEntity
    {
        public long? LikedByUserId { get; set; }

        [ForeignKey(nameof(LikedByUserId))]
        public virtual ApplicationUser LikedByByUser { get; set; }

        public long? FeedId { get; set; }
        [ForeignKey(nameof(FeedId))]
        public virtual Feed Feed { get; set; }

        public long? CommentId { get; set; }
        [ForeignKey(nameof(CommentId))]
        public virtual CommentOnFeed Comment { get; set; }

        public long? ReplyId { get; set; }
        [ForeignKey(nameof(ReplyId))]
        public virtual ReplyOnComment Reply { get; set; }

        public bool Liked { get; set; }
    }
}

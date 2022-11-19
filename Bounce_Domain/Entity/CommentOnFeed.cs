using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bounce_Domain.Entity
{
    public class CommentOnFeed : BaseEntity
    {
        public CommentOnFeed()
        {
            Replies = new HashSet<ReplyOnComment>();
        }
        public string? Comment { get; set; }
        public long? CreatedByUserId { get; set; }
        [ForeignKey(nameof(CreatedByUserId))]
        public virtual ApplicationUser CreatedByUser { get; set; }
        public long? FeedId { get; set; }
        [ForeignKey(nameof(FeedId))]
        public virtual Feed Feed { get; set; }
        public int LikeCount { get; set; }
        //[ForeignKey("CommentId")]
        public virtual ICollection<ReplyOnComment> Replies { get; set; }
        public string? Attachment { get; set; }
    }
}

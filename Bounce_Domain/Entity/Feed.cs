using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bounce_Domain.Entity
{
    public  class Feed : BaseEntity
    {
        public Feed() => Comments = new HashSet<CommentOnFeed>();
        public string? Post { get; set; }
        public long? FeedGroupId { get; set; }
        [ForeignKey(nameof(FeedGroupId))]
        public virtual FeedGroup Group { get; set; }
        public long? CreatedByUserId { get; set; }
        [ForeignKey(nameof(CreatedByUserId))]
        public virtual ApplicationUser CreatedByUser { get; set; }
        public int LikeCount { get; set; }
        

        //[ForeignKey("FeedId")]
        public virtual ICollection<CommentOnFeed> Comments { get; set; }
        public virtual ICollection<Likes> Likes { get; set; }
        public string? Attachment  { get; set; }

    }
}

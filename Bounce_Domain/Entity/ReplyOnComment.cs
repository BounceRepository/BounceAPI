using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bounce_Domain.Entity
{
    public class ReplyOnComment :BaseEntity
    {
      
        public string? Reply { get; set; }
        public long? CreatedByUserId { get; set; }
        [ForeignKey(nameof(CreatedByUserId))]
        public virtual ApplicationUser CreatedByUser { get; set; }
        public long? CommentId { get; set; }
        [ForeignKey(nameof(CommentId))]
        public virtual CommentOnFeed Comment { get; set; }
        public int LikeCount { get; set; }
        public string? Attachment { get; set; }
        public virtual ICollection<Likes> Likes { get; set; }
    }
}

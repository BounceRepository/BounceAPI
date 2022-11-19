using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace Bounce.DataTransferObject.DTO.Notification
{
    public class CommentDto
    {
        [Required]
        public long FeedId { get; set; }
        [Required]
        public string Comment { get; set; }
        [Required]
        public DateTimeOffset Time { get; set; }
    }
}

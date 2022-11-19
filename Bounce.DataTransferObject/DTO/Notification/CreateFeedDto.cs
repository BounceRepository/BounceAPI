using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bounce.DataTransferObject.DTO.Notification
{
    public class CreateFeedDto
    {
        [Required]
        [MaxLength(300)]
        public string Feed { get; set; }
        [Required]
        public long FeedGroupId { get; set; }
        [Required]
        public DateTimeOffset Time { get; set; }
    }
}

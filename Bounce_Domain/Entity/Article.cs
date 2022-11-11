using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bounce_Domain.Entity
{
    public class Article : BaseEntity
    {
        public string Title { get; set; }
        public string Text { get; set; }
        public string? BannerFilePath { get; set; }
        public long? CreatedById { get; set; }
        public virtual ApplicationUser CreatedBy { get; set; }
        public long? EditedById { get; set; }
        public virtual ApplicationUser EditedBy { get; set; }
    }
}

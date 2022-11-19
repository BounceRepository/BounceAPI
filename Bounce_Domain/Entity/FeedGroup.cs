using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bounce_Domain.Entity
{
    public class FeedGroup : BaseEntity
    {
        public string Name { get; set; }
        public virtual ICollection<Feed> Feeds { get; set; }
    }
}

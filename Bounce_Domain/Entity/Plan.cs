using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bounce_Domain.Entity
{
    public class Plan : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int Duration { get; set; }
        public double Cost { get; set; }
      
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bounce_Domain.Entity
{
    public class ConsultaionCategory : BaseEntity
    {
        public string Name { get; set; }
        public double Price { get; set; }
        public double Duration { get; set; }
    }
}

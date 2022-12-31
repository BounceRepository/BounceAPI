using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bounce_Domain.Entity
{
    public class PoolAccount : BaseEntity
    {
        public double  Balance { get; set; }

        public double Aux{ get; set; }
        public int Aux2  { get; set; }

    }
}

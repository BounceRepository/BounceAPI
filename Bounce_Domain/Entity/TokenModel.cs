using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bounce_Domain.Entity
{
    public class TokenModel : BaseEntity
    {
        public string Token { get; set; }
        public string UserEmail { get; set; }
        public string PhoneNumber { get; set; }
    }
}

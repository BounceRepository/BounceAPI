using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bounce_DbOps.MessageBus
{
    public class PersonCreatedMessage : IMessage
    {
        public string Description { get; set; }

        public Person Person { get; set; }
    }

    public class PersonDeletedMessage : IMessage
    {
        public string Description { get; set; }
    }
}

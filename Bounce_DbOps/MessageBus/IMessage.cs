using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bounce_DbOps.MessageBus
{
    public interface IMessage
    {
        string Description { get; } // Can remove or add more
    }
}

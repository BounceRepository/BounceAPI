using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bounce_DbOps.MessageBus
{
    public interface ISubscription<T> where T : IMessage
    {
        Action<T> ActionHandler { get; }
    }

    public class Subscription<T> : ISubscription<T> where T : IMessage
    {
        public Action<T> ActionHandler { get; private set; }

        public Subscription(Action<T> action)
        {
            ActionHandler = action;
        }
    }
}

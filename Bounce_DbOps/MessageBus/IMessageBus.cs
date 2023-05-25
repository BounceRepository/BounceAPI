using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bounce_DbOps.MessageBus
{
    public interface IMessageBus
    {
        void Publish<T>(T message) where T : IMessage;

        ISubscription<T> Subscribe<T>(Action<T> actionCallback) where T : IMessage;

        bool UnSubscribe<T>(ISubscription<T> subscription) where T : IMessage;

        void ClearAllSubscriptions();
    }
}

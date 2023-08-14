using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bounce.Services.MessageBus
{


    public class MessageBusService
    {
        private readonly Dictionary<Type, List<Func<object, Task>>> subscribers;

        public MessageBusService()
        {
            subscribers = new Dictionary<Type, List<Func<object, Task>>>();
        }

        public void Subscribe<TMessage>(Func<TMessage, Task> handler)
        {
            var messageType = typeof(TMessage);

            if (!subscribers.ContainsKey(messageType))
                subscribers[messageType] = new List<Func<object, Task>>();

            subscribers[messageType].Add(async message => await handler((TMessage)message));
        }

        public async Task Publish<TMessage>(TMessage message)
        {
            var messageType = typeof(TMessage);

            if (subscribers.TryGetValue(messageType, out var handlers))
            {
                foreach (var handler in handlers)
                {
                    await handler(message);
                }
            }
        }
    }




}

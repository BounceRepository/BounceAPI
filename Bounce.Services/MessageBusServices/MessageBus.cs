using Bounce.Services.MessageBusServices;
using Bounce.Services.MessageBusServices.Subscriber.Wallet;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bounce.Services.MessageBusService
{
    public class MessageBus : IMessageBus
    {
        private readonly ConcurrentDictionary<Type, List<Func<object, Task>>> _eventHandlers;
        private readonly Worker _worker;
        private readonly object _lock = new object();
        private readonly WalletTopSubscriber _walletTopSubscriber;

        public MessageBus(Worker worker, WalletTopSubscriber walletTopSubscriber)
        {
            _eventHandlers = new ConcurrentDictionary<Type, List<Func<object, Task>>>();
            _worker = worker;
            _walletTopSubscriber = walletTopSubscriber;
            Subscribe<WalletEvent>(_walletTopSubscriber.ConfirmWalletTopUpEvent);
        }

        public void Subscribe<T>(Func<T, Task> handler)
        {
            var eventType = typeof(T);
            var eventHandlers = _eventHandlers.GetOrAdd(eventType, new List<Func<object, Task>>());

            lock (_lock)
            {
                eventHandlers.Add(async message =>
                {
                    await handler((T)message);
                });
            }
        }
        public void Unsubscribe<T>(Func<T, Task> handler)
        {
            var eventType = typeof(T);

            lock (_lock)
            {
                if (_eventHandlers.TryGetValue(eventType, out var eventHandlers))
                {
                    eventHandlers.RemoveAll(x => x.Equals(handler));
                }
            }
        }

        public async Task Publish<T>(T message)
        {
            _worker.EnqueueMessage(new MessageEventWrapper<T>(message));
        }



        


    }
   
        
    
}

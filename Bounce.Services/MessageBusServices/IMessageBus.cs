using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bounce.Services.MessageBusServices
{
    public interface IMessageBus
    {
        void Subscribe<T>(Func<T, Task> handler);
        void Unsubscribe<T>(Func<T, Task> handler);
        Task Publish<T>(T message);

    }
}

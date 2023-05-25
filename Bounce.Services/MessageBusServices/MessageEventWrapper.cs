using Bounce.Services.MessageBusServices;

namespace Bounce.Services.MessageBusService
{
    public class MessageEventWrapper<T> : MessageEvent
    {
        private T? message;

        public MessageEventWrapper(T? message)
        {
            this.message = message;
        }
    }
}
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bounce.Services.MessageBusServices
{
    // Create a worker class to dequeue and process messages
    public class Worker
    {
        private readonly IMessageBus _messageBus;
        private readonly ConcurrentQueue<MessageEvent> _messageQueue;
        private readonly SemaphoreSlim _semaphore;
        private bool _isProcessing;
        private readonly object _lock = new object();

        public Worker(IMessageBus messageBus)
        {
            _messageBus = messageBus;
            _messageQueue = new ConcurrentQueue<MessageEvent>();
            _semaphore = new SemaphoreSlim(10); // Maximum of 10 requests at a time
            _isProcessing = false;
        }

        public void EnqueueMessage(MessageEvent message)
        {
            lock (_lock)
            {
                _messageQueue.Enqueue(message);

                if (!_isProcessing)
                {
                    ProcessQueue();
                }
            }
        }

        private async Task ProcessQueue()
        {
            lock (_lock)
            {
                _isProcessing = true;
            }

            while (true)
            {
                await _semaphore.WaitAsync();

                lock (_lock)
                {
                    if (_messageQueue.TryDequeue(out var message))
                    {
                        Task.Run(async () =>
                        {
                            try
                            {
                                // Process the message
                                await _messageBus.Publish(message);
                            }
                            finally
                            {
                                _semaphore.Release();
                            }
                        });
                    }
                    else
                    {
                        lock (_lock)
                        {
                            _isProcessing = false;
                            break;
                        }
                    }
                }
            }
        }
    }


   

}

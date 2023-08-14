using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bounce.Services.MessageBus
{
    public class UserCreated
    {
        public string Name { get; set; }
        public string Email { get; set; }
    }

    public class WalletBusHandler
    {
        public async Task Handle(UserCreated message)
        {
            // Simulating some async work
            await Task.Delay(1000);
            Console.WriteLine($"Sending email to {message.Email} for user {message.Name}");
        }
    }

}

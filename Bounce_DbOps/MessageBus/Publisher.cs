using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bounce_DbOps.MessageBus
{
    public class Publisher
    {
        private MessageBus messageBus;

        public Publisher(MessageBus messageBus)
        {
            this.messageBus = messageBus;
        }

        public void CreatePerson()
        {
            this.messageBus.Publish<PersonCreatedMessage>(new PersonCreatedMessage
            {
                Person = new Person { GivenName = "John" },
                Description = "[Demo 1] A new person has been created."
            });
        }
    }
}

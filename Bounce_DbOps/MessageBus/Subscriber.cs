using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bounce_DbOps.MessageBus
{
    public class Subscriber
    {
        private MessageBus messageBus;
        private ISubscription<PersonCreatedMessage> personCreatedSubscription;

        public Subscriber(MessageBus messageBus)
        {
            this.messageBus = messageBus;

            personCreatedSubscription =
                  this.messageBus.Subscribe<PersonCreatedMessage>(OnPersonCreated);
        }

        private void OnPersonCreated(PersonCreatedMessage message)
        {
            // Access message.Description, message.Person.GivenName,... here
        }

        private void Unsubscribe()
        {
            this.messageBus.UnSubscribe(personCreatedSubscription);
        }
    }
}

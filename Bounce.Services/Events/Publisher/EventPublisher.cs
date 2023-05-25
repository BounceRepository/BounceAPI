using Bounce.Services.Events.Args;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bounce.Services.Events.Publisher
{
    public class EventPublisher
    {
        public event EventHandler<WalletTopEventArgs> AppEvent;
        //public event EventHandler<MyOtherEventArgs> MyOtherEvent;

        public void RaiseEvent(WalletTopEventArgs message)
        {
            AppEvent?.Invoke(this, message);
        }

        //public void RaiseOtherEvent(int value)
        //{
        //    MyOtherEvent?.Invoke(this, new MyOtherEventArgs { Value = value });
        //}
    }

}

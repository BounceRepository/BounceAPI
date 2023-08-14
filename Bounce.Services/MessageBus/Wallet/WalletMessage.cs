using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bounce.Services.MessageBus.Wallet
{
    public class WalletMessage : IRequest<Task>
    {
        public string Trx { get; set; }
    }

    
}

using Bounce.Services.Implementation.Repositorires;
using Bounce_Application.Persistence.Interfaces.Therapist;
using Bounce_DbOps.EF;
using Bounce_Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bounce.Services.Implementation.Services.Therapist
{
    public class BankAccountDetailServices : Repository<BankAccountDetails>, IBankAccountDetailServices
    {
        public BankAccountDetailServices(BounceDbContext context) : base(context)
        {
        }
    }
}

using Bounce_Application.Persistence.Interfaces.Auth;
using Bounce_DbOps.EF;
using Bounce_Domain.Entity;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bounce.Services.Implementation.Repositorires.Auth
{
	public class RegistrationRepository : Repository<ApplicationUser>, IRegistrationRepository
	{
		public RegistrationRepository(BounceDbContext context) : base(context)
		{
		}
	}
}

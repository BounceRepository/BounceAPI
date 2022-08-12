using Bounce_Application.Persistence.Interfaces.Context;
using Bounce_Domain.Entity;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bounce_Application.Persistence.Interfaces.Auth
{
	public interface IRegistrationRepository : IRepository<ApplicationUser>
	{
	}

}

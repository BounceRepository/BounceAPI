using Bounce_Application.Persistence.Interfaces.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bounce_Application.Persistence.Interfaces
{
	public interface IUnitOfWork : IDisposable
	{
		void Commit();
		IBounceDbContext Context { get; }
		Task<int> CompletedAsync();
		int Completed();
		IRegistrationRepository RegistrationRepository { get; set; }
	}
}

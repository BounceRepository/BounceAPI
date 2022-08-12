using Bounce.Services.Implementation.Repositorires.Auth;
using Bounce_Application.Persistence.Interfaces;
using Bounce_Application.Persistence.Interfaces.Auth;
using Bounce_DbOps.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bounce.Services.Implementation.UnitOfWorks
{
	public class UnitOfWork : IUnitOfWork
	{
		private readonly BounceDbContext dbContxet;
		public UnitOfWork(BounceDbContext bounceDbContext)
		{
			RegistrationRepository = new RegistrationRepository(dbContxet);
		}
		public IBounceDbContext Context => throw new NotImplementedException();

		public void Commit()
		{
			throw new NotImplementedException();
		}

		public int Completed()
		{
			return dbContxet.SaveChanges();
		}

		public async Task<int> CompletedAsync()
		{
			return await dbContxet.SaveChangesAsync();
		}

		public void Dispose()
		{
			dbContxet.Dispose();
		}
		public IRegistrationRepository  RegistrationRepository { get; set; }
	}
}

using Bounce_Domain.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bounce_Application.Persistence.Interfaces
{
	public interface IBounceDbContext
	{
		DbSet<Error> Errors { get;  set; }
		Task<int> SaveChangesAsync(CancellationToken cancellationToken);
	}
}

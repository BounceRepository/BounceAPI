using Bounce_DbOps.EF.Infrastructure;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bounce_DbOps.EF
{
	public class BounceDbContextFactory : DesignTimeDbContextFactoryBase<BounceDbContext>
	{
		protected override BounceDbContext CreateNewInstance(DbContextOptions<BounceDbContext> options)
		{
			return new BounceDbContext(options);
		}
	}
}

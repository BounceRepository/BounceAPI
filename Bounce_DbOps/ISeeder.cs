using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bounce_DbOps
{
	public interface ISeeder
	{
		void Seed(ModelBuilder? bulder,Action? optionalAction = null);
	}
}

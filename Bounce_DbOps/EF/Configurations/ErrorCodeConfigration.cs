using Bounce_Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bounce_DbOps.EF.Configurations
{
	public class ErrorCodeConfigration : IEntityTypeConfiguration<Error>
	{
		public void Configure(EntityTypeBuilder<Error> builder)
		{
			builder.Property(e => e.Code).IsRequired();
			builder.Property(e => e.DisplayMessage);
			builder.Property(e => e.Description);
		}
	}
}

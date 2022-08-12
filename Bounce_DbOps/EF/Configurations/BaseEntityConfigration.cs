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
	public class BaseEntityConfigration : IEntityTypeConfiguration<BaseEntity>
	{
		public void Configure(EntityTypeBuilder<BaseEntity> builder)
		{
			builder.Property(e => e.IsActive);
			builder.Property(e => e.LastModifiedBy).IsRequired();
			builder.Property(e => e.IsDeleted);
			builder.Property(e => e.DateCreated);
			builder.Property(e => e.DateModified);
			builder.Property(e =>e.RowVersion).IsRowVersion().IsConcurrencyToken();
		}
	}
}

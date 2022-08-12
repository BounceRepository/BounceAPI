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
    public class TokenConfiguration : IEntityTypeConfiguration<TokenModel>
    {
		public void Configure(EntityTypeBuilder<TokenModel> builder)
		{
			builder.Property(e => e.UserEmail).IsRequired();
			builder.Property(e => e.PhoneNumber);
			builder.Property(e => e.Token).IsRequired();
		}
	}
}

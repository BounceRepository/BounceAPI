using Bounce_Application.Persistence.Interfaces;
using Bounce_DbOps.EF.Configurations;
using Bounce_Domain.Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Bounce_DbOps.EF
{
    public class BounceDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, long>, IBounceDbContext
    {
        private readonly IHttpContextAccessor httpContextAccessor = new HttpContextAccessor();
        public BounceDbContext(DbContextOptions<BounceDbContext> options) : base(options)
        {

        }
        public BounceDbContext()
        {

        }
		public DbSet<Error> Errors { get; set; }
		public DbSet<TokenModel> Tokens { get; set; }
		public DbSet<BioData> BioDatas { get; set; }
		public DbSet<Plan> Plans { get; set; }
		public DbSet<Subscription> Subscriptions { get; set; }
		public DbSet<Wallet> Wallets { get; set; }
		public DbSet<InteractiveSession> InteractiveSessions { get; set; }
		public DbSet<SerialNumber> SerialNumbers { get; set; }
		public DbSet<TherapistHospitalInformation> TherapistHospitalInformations { get; set; }
		public DbSet<TherapistmedicalRegistration> TherapistmedicalRegistrations { get; set; }
		public DbSet<BankAccountDetails> BankAccountDetails { get; set; }
		public DbSet<Article> Articles { get; set; }



		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			if (modelBuilder == null)
				return;
			foreach (var seeder in Assembly.GetExecutingAssembly().ExportedTypes
				.Where(type => type.BaseType == typeof(ISeeder)))

			{
				(Activator.CreateInstance(seeder) as ISeeder)?.Seed(modelBuilder);
			}

			modelBuilder.ApplyConfiguration(new ErrorCodeConfigration());
			base.OnModelCreating(modelBuilder);
		}

        public override int SaveChanges()
        {
			try
			{
				PerformEntityAudit();
				return base.SaveChanges();
			}
			catch (DbUpdateConcurrencyException dbEx)
			{
				foreach (var error in dbEx.Entries)
				{
					var proposedValues = error.CurrentValues;
					var databasesValues = error.GetDatabaseValues();

					foreach (var property in proposedValues.Properties)
					{
						var proposedValue = proposedValues[property];
						var database = databasesValues[property];

						proposedValues[property] = proposedValue;
					}

					error.OriginalValues.SetValues(databasesValues);
				}
			}
		  PerformEntityAudit();
		  return base.SaveChanges();
        }

		private void PerformEntityAudit()
		{
			foreach (var entity in ChangeTracker.Entries<BaseEntity>())
			{
				switch (entity.State)
				{

					case EntityState.Added:
						var currentDate = DateTime.UtcNow;
						entity.Entity.DateCreated = currentDate;
						entity.Entity.DateModified = currentDate;
						entity.Entity.IsActive = true;
						entity.Entity.IsDeleted = false;
						entity.Entity.LastModifiedBy = GetCurrentloggedUser();
						break;
					case EntityState.Modified:
						entity.Entity.DateModified = DateTime.UtcNow;
						entity.Entity.LastModifiedBy = GetCurrentloggedUser();
						break;
					case EntityState.Deleted:
						entity.State = EntityState.Modified;
						entity.Entity.LastModifiedBy = GetCurrentloggedUser();
						entity.Entity.DateModified = DateTime.UtcNow;
						entity.Entity.IsDeleted = true;
						entity.Entity.IsActive = false;
						break;
					default:
						break;
				}
			}
		}
		private string GetCurrentloggedUser()
		{
			var loggedUser = this.httpContextAccessor?.HttpContext?.User?.Identity?.Name;
			return !string.IsNullOrEmpty(loggedUser) ? loggedUser : "Anonymous";
		}
    }
}

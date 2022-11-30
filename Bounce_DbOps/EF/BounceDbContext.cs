using Bounce_Application.Persistence.Interfaces;
using Bounce_Application.Utilies;
using Bounce_DbOps.EF.Configurations;
using Bounce_Domain.Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
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
		private readonly IHttpContextAccessor httpContextAccessor;
		private  IServiceScopeFactory serviceScopeFactory { get; set; }

        public BounceDbContext(DbContextOptions<BounceDbContext> options, IServiceScopeFactory serviceScopeFactory, IHttpContextAccessor httpContextAccessor) : base(options)
        {
            this.serviceScopeFactory = serviceScopeFactory;
            this.httpContextAccessor = httpContextAccessor;
        }
        public BounceDbContext()
        {

        }
		public DbSet<Error> Errors { get; set; }
		public DbSet<TokenModel> Tokens { get; set; }
		//public DbSet<BioData> BioData { get; set; }

		public DbSet<UserProfile> UserProfile { get; set; }
		public DbSet<Plan> Plan { get; set; }
		public DbSet<Subscription> Subscriptions { get; set; }
		public DbSet<Wallet> Wallets { get; set; }
		public DbSet<WalletRequest> WalletRequests { get; set; }
		public DbSet<InteractiveSession> InteractiveSessions { get; set; }
		public DbSet<SerialNumber> SerialNumbers { get; set; }
		public DbSet<TherapistHospitalInformation> TherapistHospitalInformations { get; set; }
		public DbSet<TherapistmedicalRegistration> TherapistmedicalRegistrations { get; set; }
		public DbSet<BankAccountDetails> BankAccountDetails { get; set; }
		public DbSet<Article> Articles { get; set; }
		public DbSet<PaymentRequest> PaymentRequests { get; set; }
		public DbSet<Appointment> Appointments { get; set; }
		public DbSet<Transaction> Transactions { get; set; }
		public DbSet<AppointmentRequest> AppointmentRequest { get; set; }
		public DbSet<NotificationModel> Notification { get; set; }
		public DbSet<Chat> Chats { get; set; }
		public DbSet<Feed> Feeds { get; set; }
		public DbSet<CommentOnFeed> Comments { get; set; }
		public DbSet<ReplyOnComment> Replies { get; set; }
		public DbSet<FeedGroup> FeedGroups { get; set; }
		public DbSet<TherapistProfile> TherapistProfiles { get; set; }
		public DbSet<TherapistReview> Reviews { get; set; }
		public DbSet<FailedEmailRequest> FailedEmailRequests { get; set; }



		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			if (modelBuilder == null)
				return;
			//foreach (var seeder in Assembly.GetExecutingAssembly().ExportedTypes
			//	.Where(type => type.BaseType == typeof(ISeeder)))

			//{
			//	(Activator.CreateInstance(seeder) as ISeeder)?.Seed(bulder: modelBuilder);
			//}
			modelBuilder.SeedData();

			modelBuilder.ApplyConfiguration(new ErrorCodeConfigration());



			base.OnModelCreating(modelBuilder);
		}

        public  async Task<int> SaveChangesAsync()
        {
			try
			{
				PerformEntityAudit();
				return await base.SaveChangesAsync(acceptAllChangesOnSuccess: true);
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
		  return await base.SaveChangesAsync(acceptAllChangesOnSuccess: true);
        }


		public  override int SaveChanges()
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
						entity.Entity.LastModifiedBy = GetCurrentloggedUser() != null ? GetCurrentloggedUser().Email : "";
						//entity.Entity.CreatedByUserId = GetCurrentloggedUser() != null ? GetCurrentloggedUser().Id : null;
						break;
					case EntityState.Modified:
						entity.Entity.DateModified = DateTime.UtcNow;
						entity.Entity.LastModifiedBy = GetCurrentloggedUser() != null ? GetCurrentloggedUser().Email : "";
						//entity.Entity.ModifiedByUserId = GetCurrentloggedUser() != null ? GetCurrentloggedUser().Id : null;
						break;
					case EntityState.Deleted:
						entity.State = EntityState.Modified;
						entity.Entity.LastModifiedBy = GetCurrentloggedUser() != null ? GetCurrentloggedUser().Email: "";
						entity.Entity.DateModified = DateTime.UtcNow;
						entity.Entity.IsDeleted = true;
						entity.Entity.IsActive = false;
						//entity.Entity.ModifiedByUserId = GetCurrentloggedUser() != null ?  GetCurrentloggedUser().Id: null;
						break;
					default:
						break;
				}
			}
		}
		private ApplicationUser GetCurrentloggedUser()
		{

            using (var scope = serviceScopeFactory.CreateScope())
            {
                var context = scope.ServiceProvider.GetRequiredService<SessionManager>();
               return  context.CurrentLogin;

               

            }
        

		
		}
	
	}
}

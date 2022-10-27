using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;


namespace Bounce_DbOps.EF.Infrastructure
{
	public abstract class DesignTimeDbContextFactoryBase<TContext> : IDesignTimeDbContextFactory<TContext> where TContext : DbContext
	{
		private const string ConnectionStringName = "BounceDatabase";
		private const string AspNetCoreEnviroment = "ASPNETCORE_ENVIRONMENT";
		public TContext CreateDbContext(string[] args)
		{
			var basePath = Directory.GetCurrentDirectory();
			return Create(basePath, Environment.GetEnvironmentVariable(AspNetCoreEnviroment));
		}

		protected abstract TContext CreateNewInstance(DbContextOptions<TContext> options);

		private TContext Create(string basePath, string? environmentName)
		{
			var configuration = new ConfigurationBuilder()
				.SetBasePath(basePath)
				.AddJsonFile("appsettings.json", true, true)
				.AddJsonFile("key.json", true, true)
				.AddJsonFile("appsettings.Local.json", true, true)
				.AddJsonFile($"appsettings.{environmentName}.json", true, true)
				.AddEnvironmentVariables()
				.Build();

			var connectionString = configuration.GetConnectionString(ConnectionStringName);

			return Create(connectionString);
		}

		private TContext Create(string connectionString)
		{
			if(string.IsNullOrEmpty(connectionString))
				throw new ArgumentNullException($"Connection string '{ConnectionStringName}' is null or empty",nameof(connectionString));

			Console.WriteLine($"DesignTimeDbContextFactoryBase.Create(string) : Connection string : {connectionString}");
			var optionBuilder = new DbContextOptionsBuilder<TContext>();
			optionBuilder.UseSqlServer(connectionString);

			return CreateNewInstance(optionBuilder.Options);
		}
	}
}

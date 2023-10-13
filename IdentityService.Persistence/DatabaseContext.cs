using IdentityService.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace IdentityService.Persistence
{
	public class DatabaseContext :DbContext
	{
		public DatabaseContext
			(DbContextOptions<DatabaseContext> options) : base(options: options)
		{
			// TODO
			Database.EnsureCreated();
		}

		public DbSet<User> Users { get; set; }
		public DbSet<RevokeToken> RevokeTokens { get; set; }

		protected override void OnModelCreating
			(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);
		}
	}
}

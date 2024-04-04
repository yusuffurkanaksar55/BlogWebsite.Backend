using Microsoft.EntityFrameworkCore;
using PowerBITurkeyBlog.Entities.Entities;

namespace PowerBITurkeyBlog.DataAccess.Concrete.EntityFramework
{
	public class PowerBiTurkeyContext : DbContext
	{
		public PowerBiTurkeyContext(DbContextOptions<PowerBiTurkeyContext> options) : base(options)
		{
		}

		public PowerBiTurkeyContext()
		{
		}

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			if (!optionsBuilder.IsConfigured)
			{
				optionsBuilder.UseSqlServer("Server=localhost; Database=PowerBITurkey; TrustServerCertificate=True;Trusted_Connection=True; Integrated Security=True");
			}
		}

		public DbSet<Account> Accounts { get; set; }
		public DbSet<Article> Articles { get; set; }
		public DbSet<Comment> Comments { get; set; }
		public DbSet<Role> Roles { get; set; }
		public DbSet<Topic> Topics { get; set; }
	}

}

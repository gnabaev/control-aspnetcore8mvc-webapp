using Microsoft.EntityFrameworkCore;

namespace Control.Web.Models
{
	public class AppDbContext : DbContext
	{
		public DbSet<User> Users { get; set; }

		public DbSet<ProjectAdmin> ProjectAdmins { get; set; }

		public DbSet<Project> Projects { get; set; }

		public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
		{
			Database.EnsureCreated();
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Project>().HasData(new List<Project>()
			{
				new Project
				{
					Id = 1,
					Name = "Проект 1",
					Description = "Описание проекта 1",
					CreationDateTime = DateTime.Now,
					Status = ProjectStatus.Created
				},
				new Project
				{
					Id = 2,
					Name = "Проект 2",
					Description = "Описание проекта 2",
					CreationDateTime = DateTime.Now,
					Status = ProjectStatus.Created
				}
			});
		}
	}
}

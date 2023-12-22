using Microsoft.EntityFrameworkCore;

namespace Control.Web.Models
{
	public class AppDbContext : DbContext
	{
		public DbSet<User> Users { get; set; }

		public DbSet<Project> Projects { get; set; }

        public DbSet<UserProject> UserProjects { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
		{
			Database.EnsureCreated();
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
            modelBuilder.Entity<UserProject>().HasKey(pu => new
            {
                pu.ProjectId,
                pu.UserId
            });

            modelBuilder.Entity<UserProject>().HasOne(p => p.Project).WithMany(pu => pu.UserProjects).HasForeignKey(k => k.ProjectId);
            modelBuilder.Entity<UserProject>().HasOne(u => u.User).WithMany(pu => pu.UserProjects).HasForeignKey(k => k.UserId);

            base.OnModelCreating(modelBuilder);

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

            modelBuilder.Entity<User>().HasData(new List<User>()
            {
                new User
                {
                    Id = "1",
                    Name = "Иван",
                    Surname = "Иванов"
                },
                new User
                {
                    Id = "2",
                    Name = "Алексей",
                    Surname = "Алексеев"
                },
				new User
				{
					Id = "3",
					Name = "Федор",
					Surname = "Федоров"
				}
			});
        }
    }
}

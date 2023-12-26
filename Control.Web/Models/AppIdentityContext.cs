using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Control.Web.Models
{
	public class AppIdentityContext : IdentityDbContext<User>
	{
        public AppIdentityContext(DbContextOptions<AppIdentityContext> options) : base(options)
        {
            Database.Migrate();
        }
    }
}

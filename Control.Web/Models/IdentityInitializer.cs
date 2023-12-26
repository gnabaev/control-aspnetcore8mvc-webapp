using Microsoft.AspNetCore.Identity;
using Microsoft.VisualBasic;

namespace Control.Web.Models
{
	public class IdentityInitializer
	{
		public static void Initialize(UserManager<User> userManager, RoleManager<IdentityRole> roleManager)
		{
			if (roleManager.FindByNameAsync(UserRoles.SuperAdmin).Result == null)
			{
				roleManager.CreateAsync(new IdentityRole(UserRoles.SuperAdmin)).Wait();
			}

			if (roleManager.FindByNameAsync(UserRoles.Admin).Result == null)
			{
				roleManager.CreateAsync(new IdentityRole(UserRoles.Admin)).Wait();
			}

			if (roleManager.FindByNameAsync(UserRoles.SuperUser).Result == null)
			{
				roleManager.CreateAsync(new IdentityRole(UserRoles.SuperUser)).Wait();
			}

			if (roleManager.FindByNameAsync(UserRoles.User).Result == null)
			{
				roleManager.CreateAsync(new IdentityRole(UserRoles.User)).Wait();
			}

			var superAdminEmail = "superadmin@control.ru";
			var superAdminPassword = "!Supercontrol1396";

			if (userManager.FindByNameAsync(superAdminEmail).Result == null)
			{
				var superAdmin = new User { Email = superAdminEmail, UserName = superAdminEmail, Name = "Герман", Surname = "Набаев" };
				var superAdminCreation = userManager.CreateAsync(superAdmin, superAdminPassword).Result;

				if (superAdminCreation.Succeeded)
				{
					userManager.AddToRoleAsync(superAdmin, UserRoles.SuperAdmin).Wait();
				}
			}
		}
	}
}

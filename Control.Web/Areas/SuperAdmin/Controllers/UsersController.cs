using Control.Web.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Control.Web.Areas.SuperAdmin.Controllers
{
    [Area(nameof(UserRoles.SuperAdmin))]
    [Authorize(Roles = UserRoles.SuperAdmin)]
    public class UsersController : Controller
    {
        private readonly UserManager<User> _userManager;

        public UsersController(UserManager<User> userManager)
        {
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            var users = _userManager.Users.ToList();
            
            return View(users);
        }
    }
}

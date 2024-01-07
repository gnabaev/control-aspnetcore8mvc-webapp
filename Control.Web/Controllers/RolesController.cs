using Control.Web.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Control.Web.Controllers
{
    public class RolesController : Controller
    {
        private readonly RoleManager<IdentityRole> _manager;

        public RolesController(RoleManager<IdentityRole> manager)
        {
            _manager = manager;
        }

        public IActionResult Index()
        {
            var roles = _manager.Roles.ToList();

            return View(roles);
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(RoleViewModel roleVM)
        {
            var result = _manager.CreateAsync(new IdentityRole(roleVM.Name)).Result;

            if (result.Succeeded)
            {
                return RedirectToAction(nameof(Index));
            }
            else
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            return View(roleVM);
        }

        public IActionResult Delete(string name)
        {
            var role = _manager.FindByNameAsync(name).Result;

            if (role != null)
            {
                _manager.DeleteAsync(role);
            }

            return RedirectToAction(nameof(Index));
        }
    }
}

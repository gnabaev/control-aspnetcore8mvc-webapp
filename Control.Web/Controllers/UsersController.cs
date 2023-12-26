using Control.Web.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Control.Web.Controllers
{
	public class UsersController : Controller
	{
		private readonly UserManager<User> _userManager;
		private readonly SignInManager<User> _signInManager;

		public UsersController(UserManager<User> userManager, SignInManager<User> signInManager)
		{
			_userManager = userManager;
			_signInManager = signInManager;
		}

		public IActionResult Login()
		{
			return View(new AuthorizationViewModel());
		}

		[HttpPost]
		public async Task<IActionResult> Login(AuthorizationViewModel authorizationVM)
		{
			var user = await _userManager.FindByEmailAsync(authorizationVM.UserName);

			if (user != null)
			{
				var passwordCheck = await _userManager.CheckPasswordAsync(user, authorizationVM.Password);

				if (passwordCheck)
				{
					var result = await _signInManager.PasswordSignInAsync(user, authorizationVM.Password, false, false);

					if (result.Succeeded)
					{
						return RedirectToAction("Index", "Projects");
					}
				}

				TempData["Error"] = "Неверный E-mail или пароль. Пожалуйста, попробуйте еще раз.";

				return View(authorizationVM);
			}

			TempData["Error"] = "Неверный E-mail или пароль. Пожалуйста, попробуйте еще раз.";

			return View(authorizationVM);
		}

		public IActionResult Register()
		{
			return View(new RegistrationViewModel());
		}

		[HttpPost]
		public async Task<IActionResult> Register(RegistrationViewModel registrationVM)
		{
			var user = await _userManager.FindByEmailAsync(registrationVM.Email);

			if (user != null)
			{
				TempData["Error"] = "Данный E-mail уже существует. Пожалуйсте, войдите в аккаунт.";

				return View(registrationVM);
			}

			var newUser = new User()
			{
				Email = registrationVM.Email,
				UserName = registrationVM.Email,
				Name = registrationVM.Name,
				Surname = registrationVM.Surname,
				UserProjects = new List<UserProject>()
			};

			var newUserCreation = await _userManager.CreateAsync(newUser, registrationVM.Password);

			if (newUserCreation.Succeeded)
			{
				await _userManager.AddToRoleAsync(newUser, UserRoles.User);
			}

			return View("RegistrationCompleted");
		}

		[HttpPost]
		public async Task<IActionResult> Logout()
		{
			await _signInManager.SignOutAsync();

			return RedirectToAction("Index", "Projects");
		}
	}
}

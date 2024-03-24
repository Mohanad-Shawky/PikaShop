using System.Diagnostics;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PikaShop.Admin.Models;
using PikaShop.Data.Context.ContextEntities.Identity;

namespace PikaShop.Admin.Controllers
{
	[Authorize(Roles = "SuperAdmin,Admin")]
	public class HomeController
		(UserManager<ApplicationUserEntity> userManager,
		SignInManager<ApplicationUserEntity> signInManager)

		: Controller
	{
		readonly UserManager<ApplicationUserEntity> _userManager = userManager;
		readonly SignInManager<ApplicationUserEntity> _signInManager = signInManager;

		public async Task<IActionResult> Index()
		{
			var user = await _userManager.GetUserAsync(this.User);
			return View(user);
		}

		public IActionResult Privacy()
		{
			return View();
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}

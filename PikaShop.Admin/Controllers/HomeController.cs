using System.Diagnostics;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PikaShop.Admin.Models;
using PikaShop.Admin.ViewModels;
using PikaShop.Data.Context.ContextEntities.Identity;
using PikaShop.Services.Contracts;

namespace PikaShop.Admin.Controllers
{
	[Authorize(Roles = "SuperAdmin,Admin")]
	public class HomeController
		(UserManager<ApplicationUserEntity> userManager,
		SignInManager<ApplicationUserEntity> signInManager, IDepartmentServices departmentServices)

		: Controller
	{
		readonly UserManager<ApplicationUserEntity> _userManager = userManager;
		readonly SignInManager<ApplicationUserEntity> _signInManager = signInManager;
		readonly IDepartmentServices _departmentServices = departmentServices;

		public async Task<IActionResult> Index()
		{
			DashboardViewModel dashboardModel = new();

			dashboardModel.CustomersCount = userManager.Users.Count();

			dashboardModel.TotalSales = _departmentServices.UnitOfWork.Orders
				.GetSet().Sum(o => o.Total);

			dashboardModel.ProductsCount = _departmentServices.UnitOfWork.Products
				.GetSet().Count();

			dashboardModel.OrdersCount = _departmentServices.UnitOfWork.Orders.GetSet().Count();

			return View(dashboardModel);
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

using System.Diagnostics;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PikaShop.Admin.Models;
using PikaShop.Admin.ViewModels;
using PikaShop.Data.Context;
using PikaShop.Data.Context.ContextEntities.Identity;
using PikaShop.Services.Contracts;

namespace PikaShop.Admin.Controllers
{
	[Authorize(Roles = "SuperAdmin,Admin")]
	public class HomeController
		(UserManager<ApplicationUserEntity> userManager, RoleManager<ApplicationUserEntity> roleManager, IDepartmentServices departmentServices)

		: Controller
	{
		readonly IDepartmentServices _departmentServices = departmentServices;
		readonly UserManager<ApplicationUserEntity> _userManager = userManager;
		readonly RoleManager<ApplicationUserEntity> _roleManager = roleManager;
		public async Task<IActionResult> Index()
		{
			DashboardViewModel dashboardModel = new();

			var customerRole = await _roleManager.FindByNameAsync("Customer");

			dashboardModel.CustomersCount = await _userManager.Users
				.CountAsync(u => _userManager.IsInRoleAsync(u, "Customer").Result);

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

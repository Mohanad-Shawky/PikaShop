using System.Diagnostics;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PikaShop.Admin.Models;
using PikaShop.Admin.ViewModels;
using PikaShop.Data.Context.ContextEntities.Identity;
using PikaShop.Services.Contracts;
using PikaShop.Services.Contracts.Admin;

namespace PikaShop.Admin.Controllers
{
	[Authorize(Roles = "SuperAdmin,Admin")]
	public class HomeController
		(UserManager<ApplicationUserEntity> userManager, RoleManager<ApplicationUserEntity> roleManager, IReportGenerationServices reportGenerationServices)

		: Controller
	{
		readonly UserManager<ApplicationUserEntity> _userManager = userManager;
		readonly RoleManager<ApplicationUserEntity> _roleManager = roleManager;
		readonly IReportGenerationServices reportGenerationServices = reportGenerationServices;

		public async Task<IActionResult> Index(DateOnly from = default)
		{
			DashboardViewModel dashboardModel = new();

			var customerRole = await _roleManager.FindByNameAsync("Customer");

			dashboardModel.CustomersCount = await _userManager.Users
				.CountAsync(u => _userManager.IsInRoleAsync(u, "Customer").Result);

			dashboardModel.TotalSales = reportGenerationServices.TotalSales();

			dashboardModel.ProductsCount = reportGenerationServices.ProductCount();

			dashboardModel.OrdersCount = reportGenerationServices.OrdersCount();

			dashboardModel.LatestOrders = reportGenerationServices.LatestOrders(10).ToList();

			dashboardModel.MonthlySales = reportGenerationServices.YearMonthlySales(from).ToList();

			dashboardModel.TopSellingProducts = reportGenerationServices.BestSellingProducts(10).ToList();

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

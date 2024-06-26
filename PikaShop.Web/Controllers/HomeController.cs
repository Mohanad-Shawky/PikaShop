#nullable enable

using System.Diagnostics;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PikaShop.Web.Models;

namespace PikaShop.Web.Controllers
{
    [Authorize(Roles = "Customer")]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
          return RedirectToAction("Index", "CustomerProducts");
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

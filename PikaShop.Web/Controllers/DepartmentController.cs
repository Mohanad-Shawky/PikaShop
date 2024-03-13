using Microsoft.AspNetCore.Mvc;
using PikaShop.Data.Contracts.UnitsOfWork;
using PikaShop.Services.Contracts;
using PikaShop.Services.Core;

namespace PikaShop.Web.Controllers
{
    public class DepartmentController : Controller
    {
        IDepartmentServices services;

        public DepartmentController(IDepartmentServices _services)
        {
            services = _services;

        }
        public IActionResult Index()
        {
            return View(services.UnitOfWork.DepartmentRepository.GetAll());
        }

        //[HttpGet]
        public IActionResult Details(int id)
        {
            return View(services.UnitOfWork.DepartmentRepository.GetById(id));

        }
    }
}

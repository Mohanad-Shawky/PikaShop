using Microsoft.AspNetCore.Mvc;
using PikaShop.Data.Contracts.UnitsOfWork;

namespace PikaShop.Web.Controllers
{
    public class DepartmentController : Controller
    {
        IUnitOfWork unitOfWork;

        public DepartmentController(IUnitOfWork _uoc)
        {
            unitOfWork=_uoc;

        }
        public IActionResult Index()
        {
            return View(unitOfWork.DepartmentRepository.GetAll());
        }

        //[HttpGet]
        public IActionResult Details(int id)
        {
            return View(unitOfWork.DepartmentRepository.GetById(id));

        }
    }
}

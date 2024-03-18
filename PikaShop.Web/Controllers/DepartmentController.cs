#nullable enable

using Microsoft.AspNetCore.Mvc;
using PikaShop.Data.Contracts.UnitsOfWork;
using Microsoft.AspNetCore.Http;
using PikaShop.Data.Context.ContextEntities.Core;
using PikaShop.Services.Contracts;
using PikaShop.Services.Core;

namespace PikaShop.Web.Controllers
{
    public class DepartmentController : Controller
    {

       private IDepartmentServices departmentServices { get; }

        public DepartmentController(IDepartmentServices _depServ)
        {
            departmentServices = _depServ;

        }
        public ActionResult Index()
        {
            return View(departmentServices.UnitOfWork.Departments.GetAll());
        }

        public ActionResult Details(int id)
        {
            return View(departmentServices.UnitOfWork.Departments.GetById(id));
        }

        // GET: DepartmentController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DepartmentController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(DepartmentEntity entity)
        {
            if (entity == null) return View(entity);
            if (ModelState.IsValid)
            {

                departmentServices.UnitOfWork.Departments.Create(entity);
                departmentServices.UnitOfWork.Save();
                return RedirectToAction(nameof(Index));

            }

                return View();

        }

        // GET: DepartmentController/Edit/5
        public ActionResult Edit(int id)
        {
            return View(departmentServices.UnitOfWork.Departments.GetById(id));
        }

        // POST: DepartmentController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, DepartmentEntity entity)
        {

            if(entity ==null) return View();
            if (ModelState.IsValid)
            {

                departmentServices.UnitOfWork.Departments.UpdateById(id, entity);
                departmentServices.UnitOfWork.Save();
                return RedirectToAction(nameof(Index));
            }


            return View();
        }

        // GET: DepartmentController/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            return View();
        }

        // POST: DepartmentController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, DepartmentEntity entity)
        {
            if(entity==null)return View();
           if(ModelState.IsValid)
            {

                departmentServices.UnitOfWork.Departments.DeleteById(id);
                departmentServices.UnitOfWork.Save();
                return RedirectToAction(nameof(Index));
            }
                return View();

        }
    }
}

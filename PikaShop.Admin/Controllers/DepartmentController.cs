
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PikaShop.Admin.ViewModels;
using PikaShop.Data.Context.ContextEntities.Core;
using PikaShop.Data.Entities.Core;
using PikaShop.Services.Contracts;

namespace PikaShop.Admin.Controllers
{
    [Route("dashboard/[controller]/[action]")]
    public class DepartmentController : Controller
    {
        private IDepartmentServices _departmentServices { get; }
        private readonly IMapper _mapper;
        public DepartmentController(IDepartmentServices departmentServices, IMapper mapper)
        {
            this._departmentServices = departmentServices;
            this._mapper = mapper;
        }
        // GET: DepartmentController
        [HttpGet]
        public ActionResult Index()
        {
            var departments = _departmentServices.UnitOfWork.Departments.GetAll();
            IEnumerable<DepartmentViewModel> models = new List<DepartmentViewModel>();
            if(departments != null)
            {
                models = _mapper.Map<IQueryable<DepartmentEntity>, IEnumerable<DepartmentViewModel>>(departments);
            }
            return View(models);
        }

        // GET: DepartmentController/Details/5
        [HttpGet]
        [Route("{id:int}")]
        public ActionResult Details(int id)
        {
            var department = _departmentServices.UnitOfWork.Departments.GetById(id);
            if(department != null)
            {
                DepartmentViewModel result = _mapper.Map<DepartmentViewModel>(department);
                return View(result);
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: DepartmentController/Create
        [HttpGet]
        public ActionResult Create()
        {
            return View(new DepartmentViewModel());
        }

        // POST: DepartmentController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(DepartmentViewModel department)
        {
            try
            {
                if(department != null && ModelState.IsValid)
                {
                    DepartmentEntity entity = _mapper.Map<DepartmentViewModel, DepartmentEntity>(department);

                    _departmentServices.UnitOfWork.Departments.Create(entity);
                    _departmentServices.UnitOfWork.Save();

                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    return View(department);
                }
            }
            catch
            {
                return View(department);
            }
        }

        // GET: DepartmentController/Edit/5
        [HttpGet]
        [Route("{id:int}")]
        public ActionResult Edit(int id)
        {
            var department = _departmentServices.UnitOfWork.Departments.GetById(id);
            if(department != null)
            {
                DepartmentViewModel result = _mapper.Map<DepartmentViewModel>(department);
                return View(result);
            }
            return RedirectToAction(nameof(Index));
        }

        // POST: DepartmentController/Edit/5
        [HttpPost]
        [Route("{id:int}")]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, DepartmentViewModel department)
        {
            try
            {
                var target = _departmentServices.UnitOfWork.Departments.GetById(id);
                if(target != null && ModelState.IsValid)
                {
                    DepartmentEntity other = _mapper.Map<DepartmentViewModel, DepartmentEntity>(department);
                    _departmentServices.UnitOfWork.Departments.Update(target, other);
                    _departmentServices.UnitOfWork.Save();
                    return RedirectToAction(nameof(Index));
                }
                return View(department);
            }
            catch
            {
                return View(department);
            }
        }

        // GET: DepartmentController/Delete/5
        [HttpGet]
        public ActionResult Delete(int id)
        {
            var target = _departmentServices.UnitOfWork.Departments.GetById(id);
            if (target != null)
            {
                DepartmentViewModel result = _mapper.Map<DepartmentViewModel>(target);
                return View(result);
            }
            return RedirectToAction(nameof(Index));
        }

        // POST: DepartmentController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(DepartmentViewModel department)
        {
            try
            {
                if (department != null && ModelState.IsValid)
                {
                    DepartmentEntity target = _mapper.Map<DepartmentViewModel, DepartmentEntity>(department);
                    _departmentServices.UnitOfWork.Departments.Delete(target);
                    _departmentServices.UnitOfWork.Save();
                    return RedirectToAction(nameof(Index));
                }
                return View(department);
            }
            catch
            {
                return View(department);
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PikaShop.Data.Context;
using PikaShop.Data.Context.ContextEntities.Core;
using PikaShop.Services.Contracts;

namespace PikaShop.Web.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryServices categoryServices;

        public CategoryController(ICategoryServices _categoryService)
        {
            categoryServices = _categoryService;
        }

        // GET: Category
        public  IActionResult Index()
        {
            return View(categoryServices.UnitOfWork.Categories.GetAll());
        }

        // GET: Category/Details/5
        public IActionResult Details(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var categoryEntity = categoryServices.UnitOfWork.Categories.GetById(id);
            if (categoryEntity == null)
            {
                return NotFound();
            }

            return View(categoryEntity);
        }

        // GET: Category/Create
        public IActionResult Create()
        {
            ViewData["DepartmentId"] = new SelectList(categoryServices.UnitOfWork.Departments.GetAll(),
                "Id", "Name");
            return View();
        }

       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public  IActionResult Create( 
        CategoryEntity entity)
        {
            if (ModelState.IsValid)
            {
                categoryServices.UnitOfWork.Categories.Create(entity);
                categoryServices.UnitOfWork.Save();
                return RedirectToAction(nameof(Index));
            }
            ViewData["DepartmentId"] = new SelectList(categoryServices.UnitOfWork.Departments.GetAll(), "Id", "Description");
            return View(entity);
        }

        // GET: Category/Edit/5
        public IActionResult Edit(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var categoryEntity = categoryServices.UnitOfWork.Categories.GetById(id);
            if (categoryEntity == null)
            {
                return NotFound();
            }
            ViewData["DepartmentId"] = new SelectList(categoryServices.UnitOfWork.Departments.GetAll(), "Id", "Description");
            return View(categoryEntity);
        }

        // POST: Category/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, 
        CategoryEntity categoryEntity)
        {
            if (id != categoryEntity.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    categoryServices.UnitOfWork.Categories.UpdateById(id, categoryEntity);
                    categoryServices.UnitOfWork.Save();

                }
                catch (Exception)
                {
                    throw;
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["DepartmentId"] = new SelectList(categoryServices.UnitOfWork.Departments.GetAll(),
                "Id", "Name");
            return View(categoryEntity);
        }

        // GET: Category/Delete/5
        public  IActionResult Delete(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            CategoryEntity categoryEntity = categoryServices.UnitOfWork.Categories.GetById(id);
            if (categoryEntity == null)
            {
                return NotFound();
            }

            return View(categoryEntity);
        }

        // POST: Category/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            categoryServices.UnitOfWork.Categories.DeleteById(id);
            categoryServices.UnitOfWork.Save();


            return RedirectToAction(nameof(Index));
        }

      
    }
}

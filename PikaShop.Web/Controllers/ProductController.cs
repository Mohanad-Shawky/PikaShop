#nullable enable

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
using PikaShop.Services.Core;

namespace PikaShop.Web.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductServices productServices;

        public ProductController(IProductServices _productService)
        {
            productServices = _productService;
        }

        // GET: Product
        public IActionResult Index()
        {
            return View(productServices.UnitOfWork.Products.GetAll());
        }

        // GET: Product/Details/5
        public IActionResult Details(int id)
        {
            var productEntity = productServices.UnitOfWork.Products.GetById(id);
            if (productEntity == null)
            {
                return NotFound();
            }

            return View(productEntity);
        }

        // GET: Product/Create
        public IActionResult Create()
        {
            ViewData["CategoryId"] = new SelectList(productServices.UnitOfWork.Categories.GetAll(), "Id", "Description");
            return View();
        }

        // POST: Product/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        /*[Bind("CategoryId,CreatedAt,IsDeleted,DeletedAt,Id,Name,Description,Price,UnitsInStock")]*/
        [HttpPost]
        [ValidateAntiForgeryToken]

        public IActionResult Create( ProductEntity entity)
        {
            if (ModelState.IsValid)
            {
                productServices.UnitOfWork.Products.Create(entity);
                productServices.UnitOfWork.Save();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CategoryId"] = new SelectList(productServices.UnitOfWork.Categories.GetAll(), "Id", "Description", entity.CategoryId);
            return View(entity);
        }

        // GET: Product/Edit/5
        public IActionResult Edit(int id)
        {
            var productEntity = productServices.UnitOfWork.Products.GetById(id);
            if (productEntity == null)
            {
                return NotFound();
            }
            ViewData["CategoryId"] = new SelectList(productServices.UnitOfWork.Categories.GetAll(), "Id", "Description", productEntity.CategoryId);
            return View(productEntity);
        }

        // POST: Product/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id,  ProductEntity productEntity)
        {
            if (id != productEntity.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    productServices.UnitOfWork.Products.UpdateById(id, productEntity);
                    productServices.UnitOfWork.Save();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductEntityExists(productEntity.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["CategoryId"] = new SelectList(productServices.UnitOfWork.Categories.GetAll(), "Id", "Description", productEntity.CategoryId);
            return View(productEntity);
        }

        // GET: Product/Delete/5
        public IActionResult Delete(int id)
        {
            ProductEntity? productEntity = productServices.UnitOfWork.Products.GetById(id);
            if (productEntity == null)
            {
                return NotFound();
            }

            return View(productEntity);
        }

        // POST: Product/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            productServices.UnitOfWork.Products.DeleteById(id);
            productServices.UnitOfWork.Save();


            return RedirectToAction(nameof(Index));
        }

        private bool ProductEntityExists(int id)
        {
            return productServices.UnitOfWork.Products.GetAll().Any(p => p.Id == id);
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PikaShop.Data.Context.ContextEntities.Core;
using PikaShop.Services.Contracts;
using PikaShop.Web.ViewModels;

namespace PikaShop.Web.Controllers
{
    public class CustomerProductsController(IProductServices _prdService) : Controller
    {
        private IProductServices ProductService { get; } = _prdService;

        [HttpGet]
        public IActionResult Index(int? catId)
        {
           ViewBag.Departments= ProductService.UnitOfWork.Departments.GetAll().Include(d => d.Categories);

            IQueryable<ProductEntity> prds;
            List<ProductViewModel> prdsModel = [];
            if (catId ==null)
            {
            prds= ProductService.UnitOfWork.Products.GetAll();
            }else
            {
             prds = ProductService.UnitOfWork.Products.GetAll().Where(p => p.CategoryID == catId);
            }
            if (prds.Any())
            {
                foreach(var prd in prds)
                {
                    prdsModel.Add(IHelperMapper.ProductViewMapper(prd));
                }
            }

            return View(prdsModel);
        }

        public IActionResult Search(string searchKeyword)
        {
            ViewBag.Departments = ProductService.UnitOfWork.Departments.GetAll().Include(d => d.Categories);

            List<ProductViewModel> prdsModel = [];

            var prds = ProductService.UnitOfWork.Products.GetAll().Where(p =>p.Name.Contains(searchKeyword, StringComparison.CurrentCultureIgnoreCase));
            if (prds.Any())
            {
                foreach (var prd in prds)
                {
                    prdsModel.Add(IHelperMapper.ProductViewMapper(prd));
                }
            }
            return View("Index", prdsModel);
        }
    }
}

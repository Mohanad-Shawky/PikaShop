using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using PikaShop.Data.Context.ContextEntities.Core;
using PikaShop.Services.Contracts;
using PikaShop.Services.Core;
using PikaShop.Web.Cache;
using PikaShop.Web.ViewModels;

namespace PikaShop.Web.Controllers
{
    public class CustomerProductsController(IProductServices _prdService, CacheHelper _cacheHelper) : Controller
    {
        private IProductServices productServices { get; set; } = _prdService;
        private CacheHelper cacheHelper { get; } = _cacheHelper;

       
        [HttpGet]
        public IActionResult Index(int? catId)
        {
          
            IQueryable<ProductEntity> prds;
            cacheHelper.GetDepartments(out List <DepartmentEntity> Departments);
            cacheHelper.GetMaximumPriceRange(out double MaxPrice);
            ViewBag.Departments = Departments;
            ViewBag.MaxPrice = MaxPrice;

            List<ProductViewModel> prdsModel= new List<ProductViewModel>();
            if (catId ==null)
            {
            prds= productServices.UnitOfWork.Products.GetAll();
            }else
            {
             prds = productServices.UnitOfWork.Products.GetAll().Where(p => p.CategoryID == catId);
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
            cacheHelper.GetDepartments(out List<DepartmentEntity> Departments);
            cacheHelper.GetMaximumPriceRange(out double MaxPrice);
            ViewBag.Departments = Departments;
            ViewBag.MaxPrice = MaxPrice;

            List<ProductViewModel> prdsModel = [];

            var prds = productServices.UnitOfWork.Products.GetAll().Where(p =>p.Name.Contains(searchKeyword, StringComparison.CurrentCultureIgnoreCase));
            if (prds.Any())
            {
                foreach (var prd in prds)
                {
                    prdsModel.Add(IHelperMapper.ProductViewMapper(prd));
                }
            }
            return View("Index", prdsModel);
        }


        public IActionResult MaxPriceRange(double maxPrice)
        {
            //ViewBag.Departments = productServices.UnitOfWork.Departments.GetAll().Include(d => d.Categories);
            cacheHelper.GetDepartments(out List<DepartmentEntity> Departments);
            cacheHelper.GetMaximumPriceRange(out double MaxPrice);
            ViewBag.Departments = Departments;
            ViewBag.MaxPrice = MaxPrice;


            IQueryable<ProductEntity> prds;

            List<ProductViewModel> prdsModel = new List<ProductViewModel>();
            prds=productServices.UnitOfWork.Products.GetAll().Where(p => p.Price <= maxPrice );

            if (prds.Count() > 0)
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

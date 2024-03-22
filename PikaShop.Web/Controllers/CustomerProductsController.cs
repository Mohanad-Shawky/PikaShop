using Microsoft.AspNetCore.Mvc;

using PikaShop.Data.Context.ContextEntities.Core;
using PikaShop.Services.Contracts;
using PikaShop.Web.ViewModels;

using PikaShop.Services.Cache;
using System.Diagnostics;
using System.Text.Json;
using Newtonsoft.Json;
using PikaShop.Data.Context.Contracts;
using System.Linq;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Stripe;

namespace PikaShop.Web.Controllers
{
    public class CustomerProductsController(IProductServices _prdService, CacheHelper _cacheHelper) : Controller
    {
        private IProductServices productServices { get; set; } = _prdService;
        private CacheHelper cacheHelper { get; } = _cacheHelper;


        [HttpGet]
        public IActionResult Index(int? catId)
        {

            List<ProductViewModel> prdsModel = new List<ProductViewModel>();
            List<ProductEntity> products = productServices.GetCategoryProducts(catId);
            GetCachedValues(out List<DepartmentEntity> Departments, out double MaxPrice);
            ViewBag.Departments = Departments;
            ViewBag.MaxPrice = MaxPrice;
            ViewBag.Specification = productServices.GetCategorySpecs(catId, products);


            if (products.Count() > 0)
            {
                cacheHelper.SetProductsCache(products);
                prdsModel = products.Select(IHelperMapper.ProductViewMapper).ToList();
            }
            return View(prdsModel);
        }

        [HttpGet]
        public IActionResult Search(string searchKeyword)
        {
   
            List<ProductEntity> products = productServices.SearchByName(searchKeyword);

            List<ProductViewModel> prdsModel = new();
            if (products.Count>0)
            {
               cacheHelper.SetProductsCache(products);
               prdsModel = products.Select(IHelperMapper.ProductViewMapper).ToList();

            }
            return PartialView("_partialProductItem", prdsModel);

        }


        [HttpGet]
        public IActionResult MaxPriceRange(double maxPrice)
        {         

            cacheHelper.getProductsCache(out List<ProductEntity> cachedProducts);

           List<ProductEntity> Products=productServices.SearchByPriceRange(maxPrice, cachedProducts);
           
            List<ProductViewModel> prdsModel = Products.Select(IHelperMapper.ProductViewMapper).ToList();

            return PartialView("_partialProductItem", prdsModel);
        }



        public IActionResult SortProducts(string orderBy)
        {
         
            cacheHelper.getProductsCache(out List<ProductEntity> cachedProducts);
           List<ProductEntity> products=productServices.SortProducts(orderBy, cachedProducts);
            List<ProductViewModel> prdsModel = products.Select(IHelperMapper.ProductViewMapper).ToList();

            return PartialView("_partialProductItem", prdsModel);
        }


        [HttpGet]
        public IActionResult FeaturesFilter(string specificationJson)
        {

            var SpecificationKeys = JsonConvert.DeserializeObject<Dictionary<string, string[]>>(specificationJson);

            cacheHelper.getProductsCache(out List<ProductEntity> cachedProducts);

           List<ProductEntity> products = productServices.FilterBySpecifications(SpecificationKeys, cachedProducts);


            List<ProductViewModel> prdsModel = products.Select(IHelperMapper.ProductViewMapper).ToList();

            
            return PartialView("_partialProductItem",prdsModel);
        }


        private void GetCachedValues(out List<DepartmentEntity> Departments, out double MaxPrice)
        {
            cacheHelper.GetDepartments(out List<DepartmentEntity> _Departments);
            cacheHelper.GetMaximumPriceRange(out double _MaxPrice);
            Departments = _Departments;
            MaxPrice= _MaxPrice;
        }         

    }
}

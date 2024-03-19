using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PikaShop.Data.Context.ContextEntities.Core;
using PikaShop.Data.Entities.Core;
using PikaShop.Services.Contracts;
using PikaShop.Services.Core;
using PikaShop.Web.ViewModels;

namespace PikaShop.Web.Controllers
{
    public class CustomerProductsController : Controller
    {
        private IProductServices productServices { get; }
        public CustomerProductsController(IProductServices _prdService)
        {
            productServices = _prdService;
        }
        [HttpGet]
        public IActionResult Index(int? catId)
        {
           ViewBag.Departments= productServices.UnitOfWork.Departments.GetAll().Include(d => d.Categories);

            IQueryable<ProductEntity> prds;
                 List<ProductViewModel> prdsModel= new List<ProductViewModel>();
            if (catId ==null)
            {
            prds= productServices.UnitOfWork.Products.GetAll();
            }else
            {
             prds = productServices.UnitOfWork.Products.GetAll().Where(p => p.CategoryId == catId);
            }
            if (prds.Count() > 0)
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
            ViewBag.Departments = productServices.UnitOfWork.Departments.GetAll().Include(d => d.Categories);

            List<ProductViewModel> prdsModel = new List<ProductViewModel>();

            var prds = productServices.UnitOfWork.Products.GetAll().Where(p =>p.Name.ToLower().Contains(searchKeyword.ToLower()));
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

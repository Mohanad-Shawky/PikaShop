using PikaShop.Data.Context.ContextEntities.Core;
using PikaShop.Data.Contracts.UnitsOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PikaShop.Services.Services
{
    public class ProductServices
    {
        IUnitOfWork unitofWork;

        public ProductServices(IUnitOfWork _uow)
        {
            unitofWork = _uow;
        }
        public List<ProductEntity> GetAll()
        {
            return unitofWork.ProductRepository.GetAll().ToList();
        }
        public ProductEntity GetById(int id)
        {
            return unitofWork.ProductRepository.GetById(id);
        }

        public int Create(ProductEntity entity)
        {
            return unitofWork.ProductRepository.Create(entity);
        }
        public int Delete(int id)
        {
            return unitofWork.ProductRepository.Delete(id);
        }
        public int Update(int id, ProductEntity entity)
        {
            return unitofWork.ProductRepository.Update(id, entity);
        }
    }
}
}

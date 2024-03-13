using PikaShop.Data.Context.ContextEntities.Core;
using PikaShop.Data.Contracts.UnitsOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PikaShop.Services.Services
{
    public class CategoryServices
    {

        IUnitOfWork unitofWork;

        public CategoryServices(IUnitOfWork _uow)
        {
            unitofWork = _uow;
        }
        public List<CategoryEntity> GetAll()
        {
            return unitofWork.CategoryRepository.GetAll().ToList();
        }
        public CategoryEntity GetById(int id)
        {
            return unitofWork.CategoryRepository.GetById(id);
        }

        public int Create(CategoryEntity entity)
        {
            return unitofWork.CategoryRepository.Create(entity);
        }
        public int Delete(int id)
        {
            return unitofWork.CategoryRepository.Delete(id);
        }
        public int Update(int id, CategoryEntity entity)
        {
            return unitofWork.CategoryRepository.Update(id, entity);
        }
    }


}

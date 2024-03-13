using PikaShop.Data.Context.ContextEntities.Core;
using PikaShop.Data.Contracts.Repositories;
using PikaShop.Data.Contracts.UnitsOfWork;
using PikaShop.Data.Persistence.Repositories;
using PikaShop.Data.Persistence.UnitsOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PikaShop.Services.Services
{
    public class DepartmentServices
    {
        IUnitOfWork unitofWork;

            public DepartmentServices(IUnitOfWork _uow)
        {
            unitofWork = _uow;
        }
        public List<DepartmentEntity> GetAll()
        {
            return unitofWork.DepartmentRepository.GetAll().ToList();
        }
        public DepartmentEntity GetById(int id)
        {
            return unitofWork.DepartmentRepository.GetById(id);
        }

        public int Create(DepartmentEntity entity)
        {
            return unitofWork.DepartmentRepository.Create(entity);
        }
        public int Delete(int id)
        {
            return unitofWork.DepartmentRepository.Delete(id);
        }
        public int Update(int id,DepartmentEntity entity)
        {
            return unitofWork.DepartmentRepository.Update(id,entity);
        }
    }
}
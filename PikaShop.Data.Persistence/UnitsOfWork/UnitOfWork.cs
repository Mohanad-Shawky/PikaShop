using PikaShop.Data.Contracts.Repositories;
using PikaShop.Data.Contracts.UnitsOfWork;
using PikaShop.Data.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PikaShop.Data.Persistence.UnitsOfWork
{
    public class UnitOfWork:IUnitOfWork
    {
        public ICategoryRepository CategoryRepository { get; }

        public IDepartmentRepository DepartmentRepository { get; }

        public IProductRepository ProductRepository { get; }

        public UnitOfWork(ICategoryRepository _categoryRepo, IDepartmentRepository _departmentRepo, IProductRepository _productRepo)
        {
            CategoryRepository = _categoryRepo;
            DepartmentRepository = _departmentRepo;
            ProductRepository = _productRepo;
        }


<<<<<<< Updated upstream
=======
        public Task<int> SaveAsync()
        {
            return context.SaveChangesAsync();
        }

        public void Dispose()
        { 
             context.Dispose();
        }
>>>>>>> Stashed changes
    }
}

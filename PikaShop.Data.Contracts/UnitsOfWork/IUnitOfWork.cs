using PikaShop.Data.Contracts.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PikaShop.Data.Contracts.UnitsOfWork
{
    public interface IUnitOfWork
    {
        ICategoryRepository Categories { get; }
        IDepartmentRepository Departments { get; }
        IProductRepository Products { get; }
        ICategorySpecsRepository CategorySpecs { get; }
        IProductSpecsRepository ProductSpecs { get; }

        int Save();

        Task<int> SaveAsync();
    }
}

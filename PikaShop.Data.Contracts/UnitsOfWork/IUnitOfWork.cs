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
        ICategoryRepository CategoryRepository { get; }
        IDepartmentRepository DepartmentRepository { get; }
        IProductRepository ProductRepository { get; }

        int Save();

        Task<int> SaveAsync();
    }
}

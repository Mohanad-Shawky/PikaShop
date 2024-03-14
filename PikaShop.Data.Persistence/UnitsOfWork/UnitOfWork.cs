using PikaShop.Data.Context;
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
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        protected ApplicationDbContext context;

        public ICategoryRepository Categories { get; }

        public IDepartmentRepository Departments { get; }

        public IProductRepository Products { get; }

        public UnitOfWork(ApplicationDbContext _context)
        {
            context = _context;
            Categories = new CategoryRepository(context);
            Departments = new DepartmentRepository(context);
            Products = new ProductRepository(context);
        }

        public int Save()
        {
            return context.SaveChanges();
        }

        public Task<int> SaveAsync()
        {
            return context.SaveChangesAsync();
        }

        public void Dispose()
        {
            context.Dispose();
        }
    }
}

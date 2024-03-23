﻿using PikaShop.Data.Context;
using PikaShop.Data.Contracts.Repositories;
using PikaShop.Data.Contracts.UnitsOfWork;
using PikaShop.Data.Persistence.Repositories;

namespace PikaShop.Data.Persistence.UnitsOfWork
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        protected ApplicationDbContext context;

        public ICategoryRepository Categories { get; }

        public IDepartmentRepository Departments { get; }

        public IProductRepository Products { get; }

        public ICategorySpecsRepository CategorySpecs { get; }

        public IProductSpecsRepository ProductSpecs { get; }

        public ICartItemRepository CartItems { get; }

        public IReviewRepository Reviews { get; }

        public UnitOfWork(ApplicationDbContext _context)
        {
            context = _context;
            Categories = new CategoryRepository(context);
            Departments = new DepartmentRepository(context);
            Products = new ProductRepository(context);
            CategorySpecs = new CategorySpecsRepository(context);
            ProductSpecs = new ProductSpecsRepository(context);
            CartItems = new CartItemRepository(context);
            Reviews= new ReviewRepository(context);
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
            GC.SuppressFinalize(this);
        }
    }
}

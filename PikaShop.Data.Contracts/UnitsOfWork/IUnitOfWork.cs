﻿using PikaShop.Data.Contracts.Repositories;

namespace PikaShop.Data.Contracts.UnitsOfWork
{
    public interface IUnitOfWork
    {
        ICategoryRepository Categories { get; }
        IDepartmentRepository Departments { get; }
        IProductRepository Products { get; }
        ICategorySpecsRepository CategorySpecs { get; }
        IProductSpecsRepository ProductSpecs { get; }
        ICartItemRepository CartItems { get; }
        int Save();

        Task<int> SaveAsync();
    }
}

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
        IOrderRepository Orders { get; }

        IWishListRepository WishList { get; }

        ICartItemRepository CartItems { get; }

        IOrderItemRepository OrderItems { get; }
        int Save();

        Task<int> SaveAsync();
    }
}

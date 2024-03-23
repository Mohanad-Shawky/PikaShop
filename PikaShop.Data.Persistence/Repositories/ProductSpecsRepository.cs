using Microsoft.EntityFrameworkCore;
using PikaShop.Data.Context;
using PikaShop.Data.Context.ContextEntities.Core;
using PikaShop.Data.Contracts.Repositories;

namespace PikaShop.Data.Persistence.Repositories
{
    public class ProductSpecsRepository(ApplicationDbContext _context) : Repository<ProductSpecsEntity, int>(_context), IProductSpecsRepository
    {
        public override IQueryable<ProductSpecsEntity> GetAll()
        {
            return context.ProductSpecs.Where(ps => !ps.IsDeleted).AsNoTracking();
        }
        public IQueryable<ProductSpecsEntity> GetByProductID(int productID)
        {
            return context.ProductSpecs.Where(ps => ps.ProductID == productID).AsNoTracking();
        }
        public void UpdateById(int id, ProductSpecsEntity other)
        {
            ProductSpecsEntity? oldProductSpecs = GetById(id);
            if (oldProductSpecs != null)
            {
                oldProductSpecs.Key = other.Key;
                oldProductSpecs.Value = other.Value;
            }
        }
        public void Update(ProductSpecsEntity entity, ProductSpecsEntity other)
        {
            UpdateById(entity.ID, other);
        }
    }
}

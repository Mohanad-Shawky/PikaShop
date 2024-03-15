using Microsoft.EntityFrameworkCore;
using PikaShop.Data.Context;
using PikaShop.Data.Context.ContextEntities.Core;
using PikaShop.Data.Contracts.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PikaShop.Data.Persistence.Repositories
{
    public class ProductSpecsRepository: Repository<ProductSpecsEntity, int>, IProductSpecsRepository
    {
        public ProductSpecsRepository(ApplicationDbContext _context) : base(_context)
        {
        }

        public override IQueryable<ProductSpecsEntity> GetAll()
        {
            return context.ProductSpecs.Where(ps => ps.IsDeleted == false).AsNoTracking();
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
            UpdateById(entity.Id, other);
        }

        public void SoftDeleteById(int id)
        {
            ProductSpecsEntity? oldProSpec = GetById(id);
            if (oldProSpec != null && oldProSpec.IsDeleted == false)
            {
                oldProSpec.IsDeleted = true;
                oldProSpec.DeletedAt = DateTime.Now;
            }
        }
        public void SoftDelete(ProductSpecsEntity entity)
        {
            SoftDeleteById(entity.Id);
        }
    }
}

using Microsoft.EntityFrameworkCore;
using PikaShop.Data.Context;
using PikaShop.Data.Context.ContextEntities.Core;
using PikaShop.Data.Contracts.Repositories;

namespace PikaShop.Data.Persistence.Repositories
{
    public class CategorySpecsRepository(ApplicationDbContext _context) : Repository<CategorySpecsEntity, int>(_context), ICategorySpecsRepository
    {
        public override IQueryable<CategorySpecsEntity> GetAll()
        {
            return context.CategorySpecTemplates.Where(cs => !cs.IsDeleted).AsNoTracking();
        }

        public void UpdateById(int id, CategorySpecsEntity other)
        {
            CategorySpecsEntity? oldCategorySpecs = GetById(id);
            if (oldCategorySpecs != null)
            {
                oldCategorySpecs.Key = other.Key;
                oldCategorySpecs.Value = other.Value;
            }
        }

        public void Update(CategorySpecsEntity entity, CategorySpecsEntity other)
        {
            UpdateById(entity.ID, other);
        }

        public void SoftDeleteById(int id)
        {
            CategorySpecsEntity? oldCat = GetById(id);
            if (oldCat?.IsDeleted == false)
            {
                oldCat.IsDeleted = true;
                oldCat.DateModified = DateTime.Now;
            }
        }

        public void SoftDelete(CategorySpecsEntity entity)
        {
            SoftDeleteById(entity.ID);
        }
    }
}

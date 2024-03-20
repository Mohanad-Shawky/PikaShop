using Microsoft.EntityFrameworkCore;
using PikaShop.Data.Context;
using PikaShop.Data.Context.ContextEntities.Core;
using PikaShop.Data.Contracts.Repositories;

namespace PikaShop.Data.Persistence.Repositories
{
    public class CategoryRepository(ApplicationDbContext _context) : Repository<CategoryEntity, int>(_context), ICategoryRepository
    {
        public override IQueryable<CategoryEntity> GetAll()
        {
            return context.Categories.Where(c => !c.IsDeleted).Include(c => c.Department).AsNoTracking();
        }

        public void UpdateById(int id, CategoryEntity other)
        {
            CategoryEntity? oldCategory = GetById(id);
            if(oldCategory != null)
            {
                oldCategory.Name=other.Name;
                oldCategory.Description=other.Description;
            }
        }

        public void Update(CategoryEntity entity, CategoryEntity other)
        {
            UpdateById(entity.ID, other);
        }

        public void SoftDeleteById(int id)
        {
            CategoryEntity? oldCat = GetById(id);
            if (oldCat?.IsDeleted == false)
            {
                oldCat.IsDeleted = true;
                oldCat.DateModified = DateTime.Now;
            }
        }

        public void SoftDelete(CategoryEntity entity)
        {
            SoftDeleteById(entity.ID);
        }
    }
}

using Microsoft.EntityFrameworkCore;
using PikaShop.Data.Context;
using PikaShop.Data.Context.ContextEntities.Core;
using PikaShop.Data.Contracts.Repositories;
using PikaShop.Data.Entities.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PikaShop.Data.Persistence.Repositories
{
    public class CategoryRepository : Repository<CategoryEntity, int>, ICategoryRepository
    {

        public CategoryRepository(ApplicationDbContext _context) : base(_context)
        {
        }

        public override IQueryable<CategoryEntity> GetAll()
        {
            return context.Categories.Where(c=>c.IsDeleted==false).Include(c=>c.Department).AsNoTracking();
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
            UpdateById(entity.Id, other);
        }

        public void SoftDeleteById(int id)
        {
            CategoryEntity? oldCat = GetById(id);
            if (oldCat != null && oldCat.IsDeleted == false)
            {
                oldCat.IsDeleted = true;
                oldCat.DeletedAt = DateTime.Now;
            }
        }
        public void SoftDelete(CategoryEntity entity)
        {
            SoftDeleteById(entity.Id);
        }


    }
}

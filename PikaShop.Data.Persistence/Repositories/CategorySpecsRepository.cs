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
    public class CategorySpecsRepository: Repository<CategorySpecsEntity, int>, ICategorySpecsRepository
    {
        public CategorySpecsRepository(ApplicationDbContext _context) : base(_context)
        {
        }

        public override IQueryable<CategorySpecsEntity> GetAll()
        {
            return context.CategorySpecs.Where(cs => cs.IsDeleted == false).AsNoTracking();
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
            UpdateById(entity.Id, other);
        }

        public void SoftDeleteById(int id)
        {
            CategorySpecsEntity? oldCat = GetById(id);
            if (oldCat != null && oldCat.IsDeleted == false)
            {
                oldCat.IsDeleted = true;
                oldCat.DeletedAt = DateTime.Now;
            }
        }
        public void SoftDelete(CategorySpecsEntity entity)
        {
            SoftDeleteById(entity.Id);
        }
    }
}

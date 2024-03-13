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
    public class CategoryRepository : ICategoryRepository
    {

        private readonly ApplicationDbContext context;

        public CategoryRepository(ApplicationDbContext _context)
        {
            context = _context;
        }
        public IQueryable<CategoryEntity> GetAll()
        {
            return context.Categories.Where(c=>c.IsDeleted==false).AsNoTracking();
        }

        public CategoryEntity GetById(int id)
        {
            return context.Categories.FirstOrDefault(c => c.Id == id);
        }


        public int Create(CategoryEntity entity)
        {
            if (entity != null)
            {
                context.Add(entity);
                return context.SaveChanges();
            }
            return -1;
        }

        public int Update(int id, CategoryEntity other)
        {
            CategoryEntity oldCategory =GetById(id);
            if(oldCategory != null)
            {
                oldCategory.Name=other.Name;
                oldCategory.Description=other.Description;
                return context.SaveChanges();
            }
            return -1;
        }
        public int Delete(int id)
        {
            CategoryEntity oldCat = GetById(id);
            if (oldCat == null || oldCat.IsDeleted == true) return -1;

            oldCat.IsDeleted=true;
            oldCat.DeletedAt =DateTime.Now;
                return context.SaveChanges();
            
        }

     
    }
}

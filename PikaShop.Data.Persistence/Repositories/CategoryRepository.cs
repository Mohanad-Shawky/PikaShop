using Microsoft.EntityFrameworkCore;
using PikaShop.Data.Context;
using PikaShop.Data.Contracts.Repositories;
using PikaShop.Data.Entities.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PikaShop.Data.Persistence.Repositories
{
    public class CategoryRepository : IRepository<Category,int>
    {

        private readonly ApplicationDbContext context;

        public CategoryRepository(ApplicationDbContext _context)
        {
            context = _context;
        }
        public IQueryable<Category> GetAll()
        {
            return context.Categories.AsNoTracking();
        }

        public Category GetById(int id)
        {
            return context.Categories.FirstOrDefault(c => c.Id == id);
        }

        public int Update(int id, Category other)
        {
            Category oldCategory=GetById(id);
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
            throw new NotImplementedException();
        }
    }
}

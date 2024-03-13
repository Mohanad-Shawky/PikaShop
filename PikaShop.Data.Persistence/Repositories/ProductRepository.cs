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
    public class ProductRepository:IProductRepository
    {
        internal readonly ApplicationDbContext context = new();
        public IQueryable<ProductEntity> GetAll()
        {
            return context.Products.AsNoTracking();
        }
        public ProductEntity GetById(int id)
        {
            return context.Products.FirstOrDefault(p => p.Id == id);
        }


        public int Create(ProductEntity entity)
        {
            if(entity != null)
            {
            context.Add(entity);
            return context.SaveChanges();
            }
            return -1;
        }

        public int Update(int id, ProductEntity other)
        {
            ProductEntity editedProduct = GetById(id);
            if (editedProduct != null)
            {
                editedProduct.Description = other.Description;
                editedProduct.Price = other.Price;
                editedProduct.Name = other.Name;
                editedProduct.Specifications = other.Specifications;
                editedProduct.UnitsInStock = other.UnitsInStock;
                editedProduct.CategoryId = other.CategoryId;
                editedProduct.Category = other.Category;
                return context.SaveChanges();  
            }
            return -1;
        }
       
        public int Delete(int id)
        {
            ProductEntity oldPrd = GetById(id);
            if (oldPrd == null || oldPrd.IsDeleted == true) return -1;
                 oldPrd.IsDeleted = true;
            oldPrd.DeletedAt= DateTime.Now;
                return context.SaveChanges();
           
        }

       
    }
}

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
    internal class ProductRepository:IProductRepository
    {
        internal readonly ApplicationDbContext context;
        public IQueryable<ProductEntity> GetAll()
        {
            return context.Products.AsNoTracking();
        }
        public ProductEntity GetById(int id)
        {
            return context.Products.FirstOrDefault(p => p.Id == id);
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
        /*public int Update(ProductEntity target, ProductEntity other)
        {
            if(target!=null && other != null)
            {
                target.Id = other.Id;
                target.Description = other.Description;
                target.Price = other.Price;
                target.Name = other.Name;
                target.Specifications = other.Specifications;
                target.UnitsInStock = other.UnitsInStock;
                target.CategoryId = other.CategoryId;
                target.Category = other.Category;
                context.SaveChanges();
                return 1;
            }
            return -1;
        }

        public int Delete(ProductEntity entity)
        {
            if (entity != null)
            {
                context.Products.Remove(entity);
                return context.SaveChanges();
            }
            return -1;
        }*/
        public int DeleteById(int id)
        {
            ProductEntity deteltedProduct = GetById(id);
            if (deteltedProduct != null)
            {
                context.Products.Remove(deteltedProduct);
                return context.SaveChanges();
            }
            return -1;
        }
    }
}

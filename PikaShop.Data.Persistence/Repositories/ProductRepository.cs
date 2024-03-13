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
    public class ProductRepository :  Repository<ProductEntity, int>, IProductRepository
    {
        public ProductRepository(ApplicationDbContext context) : base(context) { }


        public void UpdateById(int id, ProductEntity other)
        {
            ProductEntity? editedProduct = GetById(id);
            if (editedProduct != null)
            {
                editedProduct.Description = other.Description;
                editedProduct.Price = other.Price;
                editedProduct.Name = other.Name;
                editedProduct.Specifications = other.Specifications;
                editedProduct.UnitsInStock = other.UnitsInStock;
                editedProduct.CategoryId = other.CategoryId;
                editedProduct.Category = other.Category;
            }
        }
        public void Update(ProductEntity entity, ProductEntity other)
        {
            UpdateById(entity.Id, other);
        }

        public void SoftDeleteById(int id)
        {
            ProductEntity? oldPrd = GetById(id);
            if (oldPrd != null && !oldPrd.IsDeleted)
            {
                oldPrd.IsDeleted = true;
                oldPrd.DeletedAt = DateTime.Now;
            }
        }
        public void SoftDelete(ProductEntity entity)
        {
            SoftDeleteById(entity.Id);
        }
    }
}

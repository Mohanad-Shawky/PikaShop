using Microsoft.EntityFrameworkCore;
using PikaShop.Data.Context;
using PikaShop.Data.Context.ContextEntities.Core;
using PikaShop.Data.Contracts.Repositories;

namespace PikaShop.Data.Persistence.Repositories
{
    public class ProductRepository(ApplicationDbContext context) :  Repository<ProductEntity, int>(context), IProductRepository
    {
        public void UpdateById(int id, ProductEntity other)
        {
            ProductEntity? editedProduct = GetById(id);
            if (editedProduct != null)
            {
                editedProduct.Description = other.Description;
                editedProduct.Price = other.Price;
                editedProduct.Name = other.Name;
                //editedProduct.Specifications = other.Specifications;
                editedProduct.UnitsInStock = other.UnitsInStock;
                editedProduct.CategoryID = other.CategoryID;
                editedProduct.Category = other.Category;
            }
        }
        public void Update(ProductEntity entity, ProductEntity other)
        {
            UpdateById(entity.ID, other);
        }

        public void SoftDeleteById(int id)
        {
            ProductEntity? oldPrd = GetById(id);
            if (oldPrd?.IsDeleted == false)
            {
                oldPrd.IsDeleted = true;
                oldPrd.DateModified = DateTime.Now;
            }
        }
        public void SoftDelete(ProductEntity entity)
        {
            SoftDeleteById(entity.ID);
        }

        public void Update(ProductEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}

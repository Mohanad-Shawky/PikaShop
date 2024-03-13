using PikaShop.Data.Context.ContextEntities.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PikaShop.Data.Contracts.Repositories
{
    public interface IProductRepository:IRepository<ProductEntity,int>
    {
        //IQueryable<ProductEntity> GetAll();
        //ProductEntity GetById(int id);

        //int Update(int id, ProductEntity other);
        ////int Update(ProductEntity target, ProductEntity other);

        ////int Delete(ProductEntity entity);
        //int Delete(int id);
    }
}

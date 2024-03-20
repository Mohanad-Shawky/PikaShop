using PikaShop.Data.Context.ContextEntities.Core;
using PikaShop.Data.Contracts.Partial;

namespace PikaShop.Data.Contracts.Repositories
{
    public interface IProductSpecsRepository:
        IRepository<ProductSpecsEntity, int>,
        ISoftDelete<ProductSpecsEntity, int>,
        IUpdate<ProductSpecsEntity, int>;
}

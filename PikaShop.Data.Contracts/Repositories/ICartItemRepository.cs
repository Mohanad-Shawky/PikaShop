using PikaShop.Data.Context.ContextEntities.Core;
using PikaShop.Data.Contracts.Partial;

namespace PikaShop.Data.Contracts.Repositories
{     
    public interface ICartItemRepository :
       IRepository<CartItemEntity, int> ,
       ISoftDelete<CartItemEntity, int>,
       IUpdate<CartItemEntity, int>;
}

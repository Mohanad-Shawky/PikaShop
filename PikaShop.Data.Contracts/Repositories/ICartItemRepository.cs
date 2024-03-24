using PikaShop.Data.Context.ContextEntities.Core;
using PikaShop.Data.Contracts.Partial;

namespace PikaShop.Data.Contracts.Repositories
{
    public interface ICartItemRepository :
       IRepository<CartItemEntity, int> ,
       IUpdate<CartItemEntity, int>
    {
        CartItemEntity? GetById(int id, string includeProperties);
        void DeleteById(int id, int id2);
    }
}

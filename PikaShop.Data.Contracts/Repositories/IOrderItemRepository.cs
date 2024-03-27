using PikaShop.Data.Context.ContextEntities.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PikaShop.Data.Contracts.Partial;


namespace PikaShop.Data.Contracts.Repositories
{
    public interface IOrderItemRepository : IRepository<OrderItemEntity, int>
    {
        public OrderItemEntity? GetByCompositeId(int productId, int orderId);
    }

}
 

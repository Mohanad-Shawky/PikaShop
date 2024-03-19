using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PikaShop.Data.Context.ContextEntities.Core;
using PikaShop.Data.Contracts.Partial;
using PikaShop.Data.Context.ContextEntities.Core;
using PikaShop.Data.Contracts.Partial;
 

namespace PikaShop.Data.Contracts.Repositories
{
    public interface ICartRepository :
    IRepository<CartEntity, int>,
    ISoftDelete<CartEntity, int>,
    IUpdate<CartEntity, int>
        {
        }
    
}

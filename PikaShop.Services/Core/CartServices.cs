using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PikaShop.Data.Context.ContextEntities.Core;
using PikaShop.Data.Contracts.Repositories;
using PikaShop.Data.Contracts.UnitsOfWork;
using PikaShop.Data.Persistence.Repositories;
using PikaShop.Data.Persistence.UnitsOfWork;
using PikaShop.Services.Contracts;
 

namespace PikaShop.Services.Core
{
    public class CartServices : ICartServices
    {
        public IUnitOfWork UnitOfWork { get; set; }
        public CartServices(IUnitOfWork _uow)
        {
            UnitOfWork = _uow;
        }

    }

   
}

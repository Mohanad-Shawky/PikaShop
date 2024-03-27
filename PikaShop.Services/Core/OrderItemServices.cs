using PikaShop.Data.Contracts.UnitsOfWork;
using PikaShop.Services.Contracts;

namespace PikaShop.Services.Core
{
    public class OrderItemServices(IUnitOfWork _uow) : Contracts.IOrderItemServices
    {

        public IUnitOfWork UnitOfWork { get; set; } = _uow;


    }

}

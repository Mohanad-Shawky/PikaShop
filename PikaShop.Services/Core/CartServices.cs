using PikaShop.Data.Contracts.UnitsOfWork;
using PikaShop.Services.Contracts;

namespace PikaShop.Services.Core
{
    public class CartServices(IUnitOfWork _uow) : ICartServices
    {
        public IUnitOfWork UnitOfWork { get; set; } = _uow;
    }
}

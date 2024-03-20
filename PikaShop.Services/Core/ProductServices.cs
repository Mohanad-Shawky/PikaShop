using PikaShop.Data.Contracts.UnitsOfWork;
using PikaShop.Services.Contracts;

namespace PikaShop.Services.Core
{
    public class ProductServices(IUnitOfWork _uow) : IProductServices
    {
        public IUnitOfWork UnitOfWork { get; set; } = _uow;
    }
}

namespace PikaShop.Data.Contracts
{
    internal interface IEntitySoftDelete
    {
        public bool IsDeleted { get; set; }
    }
}

namespace PikaShop.Data.Contracts
{
    internal interface IEntitySoftDelete
    {
        public bool IsDeleted { get; set; }
        public DateTime? DeletedAt { get; set; }
    }
}

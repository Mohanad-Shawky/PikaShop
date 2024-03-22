
namespace PikaShop.Data.Contracts.Partial
{
    public interface IUpdate<TEntity, TKey>
    {
        public void Update(TEntity entity, TEntity other);
        public void Update(TEntity entity);
        public void UpdateById(TKey key, TEntity other);
    }
}

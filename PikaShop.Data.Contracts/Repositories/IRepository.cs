using System.Linq.Expressions;

namespace PikaShop.Data.Contracts.Repositories
{
    public interface IRepository<TEntity, TKey>
        where TEntity : class
    {
        // Naming Convention
        // Select... => Get...
        // SelectBy{instance attribute} => GetBy{instance attribute}
        // SelectBy{Other instance attribute} => GetBy{Other instance attribute}
        // ex: SelectCategoryByDeparmentName => GetCategoryByDeparmentName
        // when implementing this interface :Get{EntityName}{target}
        // GetInclude(string relationship)
        // Update... => Update...
        // Delete... => Delete...
        // DeleteRange

        void Create(TEntity entity);

        void CreateRange(IEnumerable<TEntity> entities);

        IQueryable<TEntity> GetAll();

        TEntity? GetById(TKey id);

        IQueryable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);

        void Delete(TEntity entity);

        void DeleteById(TKey id);
        void DeleteById(TKey id,TKey id2);

       void DeleteRange(IEnumerable<TEntity> entities);
    }
}
